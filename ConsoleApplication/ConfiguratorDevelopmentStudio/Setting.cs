using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml;

namespace ConfiguratorDevelopmentStudio
{ 
public class Setting
{
  public Dictionary<string, string> Variables { get; set; }
  public List<Repository> Repositories { get; set; }
  public bool ForceUseAppDataPath { get; set; }

    public Setting()
    {
      this.Variables = new Dictionary<string, string>();
      this.Repositories = new List<Repository>();
      this.ForceUseAppDataPath = false;
    }

    public void LoadFromXml(string xmlFilePath)
    {
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.Load(xmlFilePath);

      XmlNodeList varNodes = xmlDoc.SelectNodes("/settings/var");
      foreach (XmlNode varNode in varNodes)
      {
        string name = varNode.Attributes["name"].Value;
        string value = varNode.Attributes["value"].Value;

        Variables[name] = value;
      }

      XmlNode blockNode = xmlDoc.SelectSingleNode("/settings/block[@name='REPOSITORIES']");
      if (blockNode != null)
      {
        XmlNodeList repositoryNodes = blockNode.SelectNodes("repository");
        foreach (XmlNode repositoryNode in repositoryNodes)
        {
          string folderName = repositoryNode.Attributes["folderName"].Value;
          string solutionType = repositoryNode.Attributes["solutionType"].Value;
          string url = repositoryNode.Attributes["url"].Value;

          Repository repository = new Repository(folderName, solutionType, url);
          Repositories.Add(repository);
        }
      }

      XmlNode metaNode = xmlDoc.SelectSingleNode("/settings/meta[@name='FORCE_USE_APPDATA_PATH']");
      if (metaNode != null)
      {
        string forceUseAppDataPathValue = metaNode.Attributes["value"].Value;
        bool.TryParse(forceUseAppDataPathValue, out bool forceUseAppDataPath);

        ForceUseAppDataPath = forceUseAppDataPath;
      }
    }
  }
}