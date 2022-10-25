namespace Demo3.Pages
{
    public partial class Index
    {
        private bool QrCodeIsHidden = true;
        private string QrCodeCssClass => QrCodeIsHidden ? "hidden" : null;
        private void Hover() => QrCodeIsHidden = !QrCodeIsHidden;
    }
}
