using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace PluginDemo
{
    public class OnCreateContact : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context =  (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            if (context.InputParameters != null)
            {

                Entity entity = (Entity)context.InputParameters["Target"];
                Guid recordId = entity.Id;



                //Entity objAccount = new Entity("account");
                //objAccount["name"] = "";
                //objAccount["description"] = "";
                //service.Create(objAccount);


                Entity accoundRecord = service.Retrieve("account", recordId, new ColumnSet(new string[] { "name", "description" }));
                accoundRecord["name"] = "From Plugin";
                accoundRecord["description"] = "";
                service.Update(accoundRecord);

                DateTime aaDate = DateTime.Now;

                

                ////entity = (Entity)context.InputParameters["Target"];
                ////Instead of getting entity from Target, we use the Image
                //Entity entity = context.PostEntityImages["PostImage"];

                //Money rate = (Money)entity.Attributes["po_rate"];
                //int units = (int)entity.Attributes["po_units"];
                //EntityReference parent = (EntityReference)entity.Attributes["po_parentid"];

                ////Multiply
                //Money total = new Money(rate.Value * units);

                ////Set the update entity
                //Entity parententity = new Entity("po_parententity");
                //parententity.Id = parent.Id;
                //parententity.Attributes["po_total"] = total;

                ////Update
                //service.Update(parententity);

            }

        }

    }
}
