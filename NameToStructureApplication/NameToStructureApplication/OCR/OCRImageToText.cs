using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace NameToStructureApplication.OCR
{
    public class OCRImageToText : TOCRdeclares
    {
        #region SDK
        private const int DIB_RGB_COLORS = 0;
        private const int DIB_PAL_COLORS = 1;
        private const int BI_RGB = 0;
        private const int BI_BITFIELDS = 3;
        private const int PAGE_READWRITE = 4;
        private const int FILE_MAP_WRITE = 2;
        private const int CBM_INIT = 4;

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }
       
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void Sleep(uint dwMilliseconds);

        [DllImport("kernel32", EntryPoint = "CreateFileMappingA", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFileMappingMy(uint hFile, uint lpFileMappingAttributes, uint flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, int lpName);

        [DllImport("kernel32", EntryPoint = "MapViewOfFile", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr MapViewOfFileMy(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

        [DllImport("kernel32", EntryPoint = "UnmapViewOfFile", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int UnmapViewOfFileMy(IntPtr lpBaseAddress);

        [DllImport("kernel32", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void CopyMemory(uint lpvDest, IntPtr lpvSrc, uint cbCopy);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern System.IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern System.IntPtr GlobalUnlock(IntPtr hMem);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GlobalFree(IntPtr hMem);

        #endregion
                
        public string GetOCRDataFromBMP(Bitmap _bmp)
        {
            string strOutput = "";
            try
            {               
                string output = GetOCRfromBMP(_bmp);               
                return output;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return strOutput;
        }

        private string GetOCRfromBMP(Bitmap bmp)
        {
            int Status;
            int JobNo = 0;
            string Answer = "";
            Bitmap BMP;
            TOCRRESULTS Results = new TOCRRESULTS();            
            TOCRJOBINFO JobInfo = new TOCRJOBINFO();

            JobInfo.ProcessOptions.DisableCharacter = new short[256];

            IntPtr MMFhandle = IntPtr.Zero;

            //BMP = new Bitmap(mSample_BMP_file);
            BMP = bmp;

            //MMFhandle = ConvertBitmapToMMF(BMP);
            MMFhandle = ConvertBitmapToMMF2(BMP);

            if (!(MMFhandle.Equals(IntPtr.Zero)))
            {
                TOCRSetErrorMode(TOCRDEFERRORMODE, TOCRERRORMODE_MSGBOX);
                JobInfo.InputFile = "";
                JobInfo.JobType = TOCRJOBTYPE_MMFILEHANDLE;
                Status = TOCRInitialise(ref JobNo);
                if (Status == TOCR_OK)
                {
                    JobInfo.PageNo = MMFhandle.ToInt32();
                    if (OCRWait(JobNo, JobInfo))
                    {
                        if (GetResults(JobNo, ref Results))
                        {
                            if (FormatResults(Results, ref Answer))
                            {
                                //MessageBox.Show(Answer, "Example 3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    TOCRShutdown(TOCRSHUTDOWNALL);
                }
                CloseHandle(MMFhandle);
            }
            return Answer;
        }

        private static IntPtr ConvertBitmapToMMF2(Bitmap BMPIn)
        {
            return ConvertBitmapToMMF2(BMPIn, true, false);
        }

        // Convert a bitmap to a memory mapped file
        // (Same as ConvertBitmapToMMF but uses CopyMemory to avoid using a byte array)
        private static IntPtr ConvertBitmapToMMF2(Bitmap BMPIn, bool DiscardBitmap, bool ConvertTo1Bit)
        {
            Bitmap BMP;
            BITMAPINFOHEADER BIH;
            BitmapData BMPData;
            int ImageSize;
            int MMFsize;
            int PalEntries;
            RGBQUAD rgb;
            GCHandle rgbGC;
            int Offset;
            IntPtr MMFhandle = IntPtr.Zero;
            IntPtr MMFview = IntPtr.Zero;
            IntPtr RetPtr = IntPtr.Zero;

            if (DiscardBitmap) // can destroy input bitmap
            {
                if (ConvertTo1Bit)
                {
                    BMP = BMPIn.Clone(new Rectangle(new Point(), BMPIn.Size), PixelFormat.Format1bppIndexed);
                    BMPIn.Dispose();
                    BMPIn = null;
                }
                else
                {
                    BMP = BMPIn;
                }
            }
            else			  // must keep input bitmap unchanged
            {
                if (ConvertTo1Bit)
                {
                    BMP = BMPIn.Clone(new Rectangle(new Point(), BMPIn.Size), PixelFormat.Format1bppIndexed);
                }
                else
                {
                    BMP = BMPIn.Clone(new Rectangle(new Point(), BMPIn.Size), BMPIn.PixelFormat);
                }
            }

            // Flip the bitmap (GDI+ bitmap scan lines are top down, GDI are bottom up)
            BMP.RotateFlip(RotateFlipType.RotateNoneFlipY);

            BMPData = BMP.LockBits(new Rectangle(new Point(), BMP.Size), ImageLockMode.ReadOnly, BMP.PixelFormat);
            ImageSize = BMPData.Stride * BMP.Height;

            PalEntries = BMP.Palette.Entries.Length;

            BIH.biWidth = BMP.Width;
            BIH.biHeight = BMP.Height;
            BIH.biPlanes = 1;
            BIH.biClrImportant = 0;
            BIH.biCompression = BI_RGB;
            BIH.biSizeImage = (uint)ImageSize;
            BIH.biXPelsPerMeter = System.Convert.ToInt32(BMP.HorizontalResolution * 100 / 2.54);
            BIH.biYPelsPerMeter = System.Convert.ToInt32(BMP.VerticalResolution * 100 / 2.54);
            BIH.biBitCount = 0;	// to avoid "Use of unassigned local variable 'BIH'"
            BIH.biSize = 0;	// to avoid "Use of unassigned local variable 'BIH'"
            BIH.biClrImportant = 0;	// to avoid "Use of unassigned local variable 'BIH'"

            // Most of these formats are untested and the alpha channel is ignored
            switch (BMP.PixelFormat)
            {
                case PixelFormat.Format1bppIndexed:
                    BIH.biBitCount = 1;
                    break;
                case PixelFormat.Format4bppIndexed:
                    BIH.biBitCount = 4;
                    break;
                case PixelFormat.Format8bppIndexed:
                    BIH.biBitCount = 8;
                    break;
                case PixelFormat.Format16bppArgb1555:
                case PixelFormat.Format16bppGrayScale:
                case PixelFormat.Format16bppRgb555:
                case PixelFormat.Format16bppRgb565:
                    BIH.biBitCount = 16;
                    PalEntries = 0;
                    break;
                case PixelFormat.Format24bppRgb:
                    BIH.biBitCount = 24;
                    PalEntries = 0;
                    break;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    BIH.biBitCount = 32;
                    PalEntries = 0;
                    break;
            }
            BIH.biClrUsed = (uint)PalEntries;
            BIH.biSize = (uint)Marshal.SizeOf(BIH);

            MMFsize = Marshal.SizeOf(BIH) + PalEntries * Marshal.SizeOf(typeof(RGBQUAD)) + ImageSize;

            MMFhandle = CreateFileMappingMy(0xFFFFFFFF, 0, PAGE_READWRITE, 0, (uint)MMFsize, 0);
            if (!(MMFhandle.Equals(IntPtr.Zero)))
            {
                MMFview = MapViewOfFileMy(MMFhandle, FILE_MAP_WRITE, 0, 0, 0);
                if (MMFview.Equals(IntPtr.Zero))
                {
                    CloseHandle(MMFhandle);
                }
                else
                {
                    Marshal.StructureToPtr(BIH, MMFview, true);
                    Offset = MMFview.ToInt32() + Marshal.SizeOf(BIH);
                    rgb.rgbReserved = 0;
                    for (int PalEntry = 0; PalEntry <= PalEntries - 1; PalEntry++)
                    {
                        rgb.rgbRed = BMP.Palette.Entries[PalEntry].R;
                        rgb.rgbGreen = BMP.Palette.Entries[PalEntry].G;
                        rgb.rgbBlue = BMP.Palette.Entries[PalEntry].B;

                        rgbGC = GCHandle.Alloc(rgb, GCHandleType.Pinned);
                        CopyMemory((uint)Offset, rgbGC.AddrOfPinnedObject(), (uint)Marshal.SizeOf(rgb));
                        rgbGC.Free();
                        Offset = Offset + Marshal.SizeOf(rgb);
                    }
                    CopyMemory((uint)Offset, BMPData.Scan0, (uint)ImageSize);
                    UnmapViewOfFileMy(MMFview);
                    RetPtr = MMFhandle;
                }
            }
            BMP.UnlockBits(BMPData);
            BMPData = null;
            BMP.Dispose();
            BMP = null;

            if (RetPtr.Equals(IntPtr.Zero))
            {
                MessageBox.Show("Failed to convert bitmap", "ConvertBitmapToMMF2", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return RetPtr;
        }

        // Wait for the engine to complete
        private static bool OCRWait(int JobNo, TOCRJOBINFO JobInfo)
        {
            int Status;
            int JobStatus = 0;
            int ErrorMode = 0;

            Status = TOCRDoJob(JobNo, ref JobInfo);
            if (Status == TOCR_OK)
            {
                Status = TOCRWaitForJob(JobNo, ref JobStatus);
            }

            if (Status == TOCR_OK && JobStatus == TOCRJOBSTATUS_DONE)
            {
                return true;
            }
            else
            {
                // If something's gone wrong display a message
                // (Check that the OCR engine hasn't already displayed a message)
                TOCRGetErrorMode(JobNo, ref ErrorMode);
                if (ErrorMode == TOCRERRORMODE_NONE)
                {
                    StringBuilder Msg = new StringBuilder(TOCRJOBMSGLENGTH);
                    TOCRGetJobStatusMsg(JobNo, Msg);
                    MessageBox.Show(Msg.ToString(), "OCRWait", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
        }

        // OVERLOADED function to retrieve the results from the service process and load into 'Results'
        // Remember the character numbers returned refer to the Windows character set.
        private static bool GetResults(int JobNo, ref TOCRRESULTS Results)
        {
            int ResultsInf = 0; // number of bytes needed for results
            byte[] Bytes;
            int Offset;
            bool RetStatus = false;
            GCHandle BytesGC;
            System.IntPtr AddrOfItemBytes;

            Results.Hdr.NumItems = 0;
            if (TOCRGetJobResults(JobNo, ref ResultsInf, 0) == TOCR_OK)
            {
                if (ResultsInf > 0)
                {
                    Bytes = new Byte[ResultsInf - 1];
                    // pin the Bytes array so that TOCRGetJobResults can write to it
                    BytesGC = GCHandle.Alloc(Bytes, GCHandleType.Pinned);
                    if (TOCRdeclares.TOCRGetJobResults(JobNo, ref ResultsInf, ref Bytes[0]) == TOCR_OK)
                    {
                        Results.Hdr = ((TOCRRESULTSHEADER)(Marshal.PtrToStructure(BytesGC.AddrOfPinnedObject(), typeof(TOCRRESULTSHEADER))));
                        if (Results.Hdr.NumItems > 0)
                        {
                            Results.Item = new TOCRRESULTSITEM[Results.Hdr.NumItems];
                            Offset = Marshal.SizeOf(typeof(TOCRRESULTSHEADER));
                            for (int ItemNo = 0; ItemNo <= Results.Hdr.NumItems - 1; ItemNo++)
                            {
                                AddrOfItemBytes = Marshal.UnsafeAddrOfPinnedArrayElement(Bytes, Offset);
                                Results.Item[ItemNo] = ((TOCRRESULTSITEM)(Marshal.PtrToStructure(AddrOfItemBytes, typeof(TOCRRESULTSITEM))));
                                Offset = Offset + Marshal.SizeOf(typeof(TOCRRESULTSITEM));
                            }
                        }

                        RetStatus = true;

                        // Double check results
                        if (Results.Hdr.StructId == 0)
                        {
                            if (Results.Hdr.NumItems > 0)
                            {
                                if (Results.Item[0].StructId != 0)
                                {
                                    MessageBox.Show("Wrong results item structure Id " + Results.Item[0].StructId.ToString(), "GetResults", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Results.Hdr.NumItems = 0;
                                    RetStatus = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong results header structure Id " + Results.Item[0].StructId.ToString(), "GetResults", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Results.Hdr.NumItems = 0;
                            RetStatus = false;
                        }
                    }
                    BytesGC.Free();
                }
            }
            return RetStatus;
        }

        // OVERLOADED function to convert results to a string
        private static bool FormatResults(TOCRRESULTS Results, ref string Answer)
        {
            Answer = "";

            if (Results.Hdr.NumItems > 0)
            {
                for (int ItemNo = 0; ItemNo < Results.Hdr.NumItems; ItemNo++)
                {
                    if (Results.Item[ItemNo].OCRCha == 13)
                        Answer = Answer + Environment.NewLine;
                    else
                        Answer = Answer + Convert.ToChar(Results.Item[ItemNo].OCRCha);
                }
                return true;
            }
            else
            {
                MessageBox.Show("No results returned", "FormatResults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }        
    }
}
