using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing;

using ZXing.OneD;

namespace PrinterTest
{
    static class BarCode
    {
        public static Bitmap DrawBarCode(string data, BarcodeFormat format, int width, int height)
        {
            BitMatrix bm;
            try
            {
                switch (format)
                {
                    case BarcodeFormat.UPC_A:
                        UPCAWriter writer = new UPCAWriter();
                        bm = writer.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.UPC_E:
                        UPCEWriter upcew = new UPCEWriter();
                        bm = upcew.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.EAN_8:
                        EAN8Writer ean8w = new EAN8Writer();
                        bm = ean8w.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.EAN_13:
                        EAN13Writer ean13w = new EAN13Writer();
                        bm = ean13w.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.CODE_39:
                        Code39Writer c39w = new Code39Writer();
                        bm = c39w.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.ITF:
                        ITFWriter iw = new ITFWriter();
                        bm = iw.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.CODABAR:
                        CodaBarWriter cbw = new CodaBarWriter();
                        bm = cbw.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.CODE_93:
                        Code93Writer c93w = new Code93Writer();
                        bm = c93w.encode(data, format, width, height);
                        break;

                    case BarcodeFormat.CODE_128:
                        Code128Writer c128w = new Code128Writer();
                        bm = c128w.encode(data, format, width, height);
                        break;

                    default:
                        return null;
                }
                BarcodeWriter bw = new BarcodeWriter();
                return bw.Write(bm);
            }
            catch
            {
                return new Bitmap(10, 10);
            }
        }

        public static Bitmap DrawQRCode(string data, int width, int level = -1, int version = -1 )
        {
            ErrorCorrectionLevel[] ecl = { ErrorCorrectionLevel.L, ErrorCorrectionLevel.M, ErrorCorrectionLevel.Q, ErrorCorrectionLevel.H };
            Dictionary<EncodeHintType, object> hintDict = new Dictionary<EncodeHintType, object>();
            if (level >= 0 && level <= 3)
            {
                hintDict.Add(EncodeHintType.ERROR_CORRECTION, ecl[level]);
            }
            if(version >=0 && version <= 20)
            {
                hintDict.Add(EncodeHintType.QR_VERSION, version);
            }

            BarcodeFormat bf =  BarcodeFormat.QR_CODE;
            QRCodeWriter qcr = new QRCodeWriter();
            BitMatrix bm = qcr.encode(data, bf, width, width, hintDict);
            BarcodeWriter bw = new BarcodeWriter();
            return bw.Write(bm);
        }

        
    }
}
