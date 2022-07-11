using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLCyclofan.Models
{
    public class Workspace
    {
        private Device device = new Device();
        private List<Tool> tools = new List<Tool>();

        public Device Device { get => device; set => device = value; }
        public List<Tool> Tools { get => tools; set => tools = value; }

        public Workspace()
        { }

        #region Part
        public (bool reply, string message) RemovePart(Part part, Tool tool)
        {
            var finaMessage = string.Empty;
            var reply = false;

            var currentPart = device.Parts.Find(cPart => cPart.Id.Equals(part.Id));

            if (currentPart.CorrectTool(tool))
            {
                var allowedRemoveResult = device.PartAllowedToBeRemoved(currentPart);
                if(allowedRemoveResult.reply)
                {
                    currentPart.Assembled(false);
                    reply = true;
                    finaMessage = $"A peça \"{currentPart.Type}\" foi REMOVIDA!";
                }
                else
                {
                    var partList = string.Empty;

                    foreach(var partImp in allowedRemoveResult.parts)
                    {
                        partList += $"  ID: {partImp.Id}   {partImp.Type}";
                    }

                    reply = false;
                    finaMessage = $"A peça \"{currentPart.Type}\" não pode ser removida! Há outras partes a serem removidas antes dela. List: {partList}";
                }
            }
            else
            {
                reply = false;
                finaMessage = $"A ferramenta \"{tool.Type}\" é INCORRETA para remover a peça \"{part.Type}\"";
            }
                
            return (reply, finaMessage);
        }
        #endregion

        #region Tool
        public Tool GetToolById(string toolId)
        {
            var tool = tools.Find(tool => tool.Id.Equals(toolId));
            return tool;
        }

        #endregion


    }
}
