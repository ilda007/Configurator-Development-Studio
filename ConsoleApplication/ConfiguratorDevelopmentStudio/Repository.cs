using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguratorDevelopmentStudio
{
  public class Repository
  {
    public string FolderName { get; set; }
    public string SolutionType { get; set; }
    public string Url { get; set; }

    public Repository(string folderName, string solutionType, string url)
    {
      this.FolderName = folderName;
      this.SolutionType = solutionType;
      this.Url = url;
    }
  }
}
