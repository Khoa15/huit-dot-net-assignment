using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalDocumentary.GUI
{
    internal class Notification
    {
        public static DialogResult Notify(string content)
        {
            return MessageBox.Show(content, "Thông báo");
        }

        public static DialogResult Success()
        {
            return MessageBox.Show("Thành công!", "Thông báo");
        }
        public static DialogResult Fail()
        {
            return MessageBox.Show("Thất bại!", "Thông báo");
        }
        public static DialogResult ConfirmDelete(string message = null)
        {
            if(message == null) {
                message = "Bạn có chắc chắn xóa biểu ghi này?";
            }
            return MessageBox.Show(message, "Thông báo", MessageBoxButtons.OKCancel);
        }
        public static DialogResult ConfirmPublicAllDocs()
        {
            return MessageBox.Show("Bạn có chắc chắn ban hành tất cả tài liệu trong thư mục này?", "Thông báo", MessageBoxButtons.OKCancel);
        }
        public static DialogResult ConfirmUnPublicAllDocs()
        {
            return MessageBox.Show("Bạn có chắc chắn hủy ban hành tất cả tài liệu trong thư mục này?", "Thông báo", MessageBoxButtons.OKCancel);
        }
    }
}
