
using System.Globalization;
namespace CafeStoreWeb.Pages.Dashboard;

public partial class Dashboard
{
    public string Name { get; set; } = "Mengly";
    public List<string> ListOutlets { get; set; }= new List<string>() {"PTK","PBT","PSV","FPAM" };
    public List<string> ListItemPopulars { get; set; }= new List<string>() {"Food","Baverage","Set Item", "Souvenir" };

    public Dashboard()
    {
  
    }
}
