using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Chess.Model {
    public class BoardImpl : Board {

        public Vji.Chess.Model.Factory Factory { set; get; }
        private Location[,] Locations { set; get; }

        public BoardImpl() {
            Locations = new Location[File.Items.Count, Rank.Items.Count];
        }
        
        private Shade DetermineShade(File file, Rank rank) {
            
            // Set initial shade
            Shade theShade = Shade.Light;
            
            // Find the shade for the start of each rank
            foreach(Rank rankRow in Rank.Items.Reverse()) {
                if (rank == rankRow) {
                    break;
                }
                if (theShade == Shade.Light) {
                    theShade = Shade.Dark;
                }
                else {
                    theShade = Shade.Light;
                }
            }
            
            // Find the shade for the file
            foreach(File fileColumn in File.Items) {
                if (file == fileColumn) {
                    break;
                }
                if (theShade == Shade.Light) {
                    theShade = Shade.Dark;
                }
                else {
                    theShade = Shade.Light;
                }
            }
            
            return theShade;
        }

        public void SetLocationAt(Location location, File file, Rank rank) {
            Locations[file.Idx, rank.Idx] = location;
        }

        public Location GetLocationAt(File file, Rank rank) {
            Location location = Locations[file.Idx, rank.Idx];
            if (location == null) {
                location = Factory.NewLocation(this.DetermineShade(file, rank));
                SetLocationAt(location, file, rank);
            }
            return location;
        }

        public void PlacePieceAt(Piece piece, File file, Rank rank) {
            GetLocationAt(file, rank).Piece = piece;
        }

        public Piece GetPieceAt(File file, Rank rank) {
            return GetLocationAt(file, rank).Piece;
        }

        public void ArrangePieces() {

            PlacePieceAt(Factory.NewRook(Colour.Black), File.FileA, Rank.Rank8);
            PlacePieceAt(Factory.NewKnight(Colour.Black), File.FileB, Rank.Rank8);
            PlacePieceAt(Factory.NewBishop(Colour.Black), File.FileC, Rank.Rank8);
            PlacePieceAt(Factory.NewQueen(Colour.Black), File.FileD, Rank.Rank8);
            PlacePieceAt(Factory.NewKing(Colour.Black), File.FileE, Rank.Rank8);
            PlacePieceAt(Factory.NewBishop(Colour.Black), File.FileF, Rank.Rank8);
            PlacePieceAt(Factory.NewKnight(Colour.Black), File.FileG, Rank.Rank8);
            PlacePieceAt(Factory.NewRook(Colour.Black), File.FileH, Rank.Rank8);

            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileA, Rank.Rank7);
            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileB, Rank.Rank7);
            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileC, Rank.Rank7);
            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileD, Rank.Rank7);
            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileE, Rank.Rank7);
            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileF, Rank.Rank7);
            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileG, Rank.Rank7);
            PlacePieceAt(Factory.NewPawn(Colour.Black), File.FileH, Rank.Rank7);
            
            Rank[] ranks = new Rank[] {Rank.Rank6, Rank.Rank5, Rank.Rank4, Rank.Rank3};
            foreach(Rank rank in ranks) {
                foreach(File file in File.Items) {
                    this.PlacePieceAt(null, file, rank);
                }
            }

            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileA, Rank.Rank2);
            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileB, Rank.Rank2);
            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileC, Rank.Rank2);
            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileD, Rank.Rank2);
            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileE, Rank.Rank2);
            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileF, Rank.Rank2);
            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileG, Rank.Rank2);
            PlacePieceAt(Factory.NewPawn(Colour.White), File.FileH, Rank.Rank2);

            PlacePieceAt(Factory.NewRook(Colour.White), File.FileA, Rank.Rank1);
            PlacePieceAt(Factory.NewKnight(Colour.White), File.FileB, Rank.Rank1);
            PlacePieceAt(Factory.NewBishop(Colour.White), File.FileC, Rank.Rank1);
            PlacePieceAt(Factory.NewQueen(Colour.White), File.FileD, Rank.Rank1);
            PlacePieceAt(Factory.NewKing(Colour.White), File.FileE, Rank.Rank1);
            PlacePieceAt(Factory.NewBishop(Colour.White), File.FileF, Rank.Rank1);
            PlacePieceAt(Factory.NewKnight(Colour.White), File.FileG, Rank.Rank1);
            PlacePieceAt(Factory.NewRook(Colour.White), File.FileH, Rank.Rank1);
        }
        
        public void PerformMove(Move move) {
            Piece piece = this.GetPieceAt(move.FromFile, move.FromRank);
            this.PlacePieceAt(null, move.FromFile, move.FromRank);
            this.PlacePieceAt(piece, move.ToFile, move.ToRank);
        }

    }
}
