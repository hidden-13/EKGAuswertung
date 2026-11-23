using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace ChartTestFramwork
{
    internal class ModelXML : IModelLocalData
    {

        private IModelECGDevice modelECGDevice;
        private IControllerECG controllerECG;
        private IViewECG viewECG;
        private XDocument doc;

        IViewECG IModelLocalData.ViewEKG { set => viewECG=value; }
        IModelECGDevice IModelLocalData.ModelECGDevice { set => modelECGDevice=value; }
        IControllerECG IModelLocalData.ControllerECG { set => controllerECG=value; }


        public ModelXML() 
        {
            doc = new XDocument();
        }

        List<double> IModelLocalData.get24hData()
        {
            throw new NotImplementedException();
        }

        void IModelLocalData.saveLiveData(ECGValue aktuellerWert)
        {
            doc.Root.Add(new XElement("Value",
            new XAttribute("time", DateTime.Now.ToString("o")),
            aktuellerWert.ToString()));

            doc.Save(FilePath);
        }

        void IModelLocalData.set24hData(ECGValue aktuellerWert)
        {
            throw new NotImplementedException();
        }
    }
}
