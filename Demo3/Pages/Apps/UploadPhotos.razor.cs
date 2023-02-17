using AntDesign;

namespace Demo3.Pages.Apps
{
    public partial class UploadPhotos
    {
        bool previewVisible = false;
        string previewTitle = string.Empty;
        string imgUrl = string.Empty;

        List<UploadFileItem> fileList = new List<UploadFileItem>
{
        new UploadFileItem
        {
            Id = "1",
            FileName = "image.png",
            State = UploadState.Success,
            Url = "https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
        },
        new UploadFileItem
        {
            Id = "2",
            FileName = "image.png",
            State = UploadState.Success,
            Url = "https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
        },
        new UploadFileItem
        {
            Id = "3",
            FileName = "image.png",
            State = UploadState.Success,
            Url = "https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
        },
        new UploadFileItem
        {
            Id = "4",
            FileName = "image.png",
            State = UploadState.Success,
            Url = "https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
        },
        new UploadFileItem
        {
            Id = "xxx",
            FileName = "image.png",
            State = UploadState.Uploading,
            Percent = 50,
            Url = "https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
        },
         new UploadFileItem
        {
            Id = "5",
            FileName = "image.png",
            State = UploadState.Fail
        },
    };

        void HandleChange(UploadInfo fileinfo)
        {
            if (fileinfo.File.State == UploadState.Success)
            {
                fileinfo.File.Url = fileinfo.File.ObjectURL;
            }
        }

        public class ResponseModel
        {
            public string name { get; set; }

            public string status { get; set; }

            public string url { get; set; }

            public string thumbUrl { get; set; }
        }
    }
}
