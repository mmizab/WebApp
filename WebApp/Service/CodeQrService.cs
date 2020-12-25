using System.Drawing;
using QRCoder;
using WebApp.Controllers;

namespace WebApp.Service
{
    public class CodeQrService
    {
        public static byte[] GenerateQr(string url) {
            QRCodeGenerator QRCodeGenerator = new QRCodeGenerator();
            QRCodeData QRCodeData = QRCodeGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(QRCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            byte[] qrBytecode = BaseController.BitmapToBytesCode(qrCodeImage);
            return qrBytecode;
        }
    }
}
