using CoffeePointOfSale.Configuration;
using CoffeePointOfSale.Services;

namespace CoffeePointOfSale
{
    public partial class MainForm : Form
    {
        private readonly IHelloService _helloService;
        private readonly AppSettings _appSettings;

        public MainForm(IHelloService helloService, AppSettings appSettings)
        {
            InitializeComponent();
            this._helloService = helloService;
            _appSettings = appSettings;
            MessageBox.Show(_helloService.SayHello(_appSettings.Name));
        }
    }
}