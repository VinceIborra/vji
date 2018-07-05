using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Vji.Mvc;
using Vji.Chess.Model;

namespace Vji.Chess.Mvc {
    public class ChessNotationParserImpl : Parser {
        
        private static string _MOVE_EXPR = "^([prnbqk])([a-h])([1-8])(x?)([a-h])([1-8])$";
        private static string _EXIT_EXPR = "^exit$";
        
        private Regex MovePattern { set; get; }
        private Regex ExitPattern { set; get; }
        
        public Vji.Chess.Model.Factory ChessFactory { set; get; }
        public Vji.Chess.Mvc.Factory MvcFactory { set; get; }
        
        
        public ChessNotationParserImpl() {
            this.MovePattern = new Regex(_MOVE_EXPR, RegexOptions.IgnoreCase);
            this.ExitPattern = new Regex(_EXIT_EXPR, RegexOptions.IgnoreCase);
        }
        
        public Command Parse(string message) {

            // Normalise to lower case
            String msg = message.Trim().ToLower();
    
//            // Arrange command
//            Matcher arrangeMatcher = getArrangePattern().matcher(msg);
//            if (arrangeMatcher.matches()) {
//                return getChessMvcFactory().newArrangeCommand();
//            }

            // Move command
            MatchCollection matches = this.MovePattern.Matches(msg);
            if (matches.Count > 0) {
   
                // Piece class
                Type pieceType = null;
                if     (matches[0].Groups[1].Value == "p")
                    pieceType = typeof(Pawn);
                else if(matches[0].Groups[1].Value == "r")
                    pieceType = typeof(Rook);
                else if(matches[0].Groups[1].Value == "n")
                    pieceType = typeof(Knight);
                else if(matches[0].Groups[1].Value == "b")
                    pieceType = typeof(Bishop);
                else if(matches[0].Groups[1].Value == "q")
                    pieceType = typeof(Queen);
                else if(matches[0].Groups[1].Value == "k")
                    pieceType = typeof(King);
    
                // From location
                File fromFile = File.FromString(matches[0].Groups[2].Value);
                Rank fromRank = Rank.FromString(matches[0].Groups[3].Value);
    
                // Capture
                bool capture = false;
                if (matches[0].Groups[4].Value == "x") {
                    capture = true;
                }
    
                // To location
                File toFile = File.FromString(matches[0].Groups[5].Value);
                Rank toRank = Rank.FromString(matches[0].Groups[6].Value);
                
                // Create move
                Move move = this.ChessFactory.NewMove(pieceType, fromFile, fromRank, toFile, toRank, capture);
    
                // Create and return the corresponding command
                return this.MvcFactory.NewMoveCommand(move);
            }
    
            // Exit command
            if (this.ExitPattern.IsMatch(msg)) {
                return this.MvcFactory.NewFinishCommand();
            }
    
            // Unknown Command
            return this.MvcFactory.NewUnknownCommand("Could not parse command \"" + message + "\".");
        }
    }
}
