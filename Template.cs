using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Analyzer;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace WebinarLibrary
{
    public class RuleRepositoryNo1 : IRegisterAnalyzerConfiguration //To do: Change number of Rule Repository with every rule
    {
        public void Initialize(IAnalyzerConfigurationService workflowAnalyzerConfigService)
        {
            if (!workflowAnalyzerConfigService.HasFeature("WorkflowAnalyzerV4"))
                return;

            var nameOfTheRule = new Rule<IWorkflowModel>("Rule name that will be displayed in Studio", "Rule ID", FunctionName); //Scope: Workflow | Check Rules Naming Convention in documenation --> TO DO: Change 
            nameOfTheRule.RecommendationMessage = "Recommendation message"; // TO DO: Change recommendation message
            nameOfTheRule.ErrorLevel = System.Diagnostics.TraceLevel.Warning; // Specfies what level of warning message would it be
            nameOfTheRule.DefaultErrorLevel = System.Diagnostics.TraceLevel.Error; 
            ((AnalyzerInspector)nameOfTheRule).ApplicableScopes = new List<string>()
            {
                "DevelopmentRule"
            };
            workflowAnalyzerConfigService.AddRule<IWorkflowModel>(nameOfTheRule);
        }

        private InspectionResult FunctionName(IWorkflowModel workflowToInspect, UiPath.Studio.Activities.Api.Analyzer.Rules.Rule configuredRule)
        {
            List<string> stringList = new List<string>();  
            if (!RuleRepositoryNo1.CheckSomething(workflowToInspect.Root))
                stringList.Add("Descrition of rule message" + ((IInspectionObject)workflowToInspect).DisplayName + "."); // TO DO: Change descrition of rule message
            if (stringList.Count > 0)
                return new InspectionResult()
                {
                    ErrorLevel = configuredRule.ErrorLevel,
                    HasErrors = true,
                    RecommendationMessage = configuredRule.RecommendationMessage,
                    Messages = (ICollection<string>)stringList
                };
            return new InspectionResult() { HasErrors = false };
        }

        private static bool CheckSomething(IActivityModel activityModel)
        {
            // Code for checking out something
            return true;
        }
    }
}
