using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QQMusic
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public void ApplySkin(string newPaths, string oldxamls)
        {
            Collection<ResourceDictionary> mergedDicts = base.Resources.MergedDictionaries;
            string[] ss = oldxamls.Split(',');
            if (ss.Length > 0)
            {
                foreach (var path in ss)
                {
                    if (mergedDicts.Count > 0 && path.Trim() != "")
                    {
                        foreach (var item in mergedDicts)
                        {
                            if (item.Source.OriginalString.Trim().EndsWith(path.Trim()))
                            {
                                mergedDicts.Remove(item);
                                break;
                            }
                        }
                    }
                }
            }
            if (newPaths != "")
            {
                try
                {
                    string[] newss = newPaths.Split(',');
                    if (newss.Length > 0)
                    {
                        foreach (var item in newss)
                        {
                            Uri skinDictionaryUri = new Uri(item, UriKind.Relative);
                            ResourceDictionary skinDict = new ResourceDictionary();
                            //ResourceDictionary skinDict = Application.LoadComponent(skinDictionaryUri) as ResourceDictionary;
                            skinDict.Source = skinDictionaryUri;

                            mergedDicts.Add(skinDict);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dsds:" + ex.Message);
                }

            }
        }
    }
}
