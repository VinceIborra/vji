using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Exceptions;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {
    public class UnknownCommandViewImpl : BoardViewImpl, View {

        protected void AssertCommentInModel(IDictionary<string, Object> model) {
            this.AssertValidModel(model);
            if (!model.ContainsKey("Comment") || !(model["Comment"] is string)) {
                throw new InternalErrorException(
                    "Expected component \"Comment\" to be present in the model - " + model + "."
                );
            }

        }
        
        private string RenderUnknownCommandMessage(string comment) {
            return "An unknown command was entered - " + comment + "\n" +
                   "Please try again\n" +
                   "\n";
        }

        public new string Render(IDictionary<string, Object> model) {
            this.AssertBoardInModel(model);
            this.AssertCommentInModel(model);
            string str = this.RenderUnknownCommandMessage((string) model["Comment"])
                       + this.RenderBoard((Board) model["Board"])
                       + this.RenderPrompt();
            return str;
        }
    }
}
