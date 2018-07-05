require 'vji'
require 'chess'

module Chess
  class Factory

    include Assertions

    def new_square(file, rank, shade)
      assert_valid_file file
      assert_valid_rank rank
      assert_valid_shade shade
      square = Square.new
      square.file = file
      square.rank = rank
      square.shade = shade
      return square
    end
    def new_board
      board = Board.new
      board.factory = self
      board.tracker = self.new_tracker
      board.setup
      return board
    end

    def new_pawn(colour)
      piece = Pawn.new
      piece.colour = colour
      return piece
    end
    def new_rook(colour)
      piece = Rook.new
      piece.colour = colour
      return piece
    end
    def new_knight(colour)
      piece = Knight.new
      piece.colour = colour
      return piece
    end
    def new_bishop(colour)
      piece = Bishop.new
      piece.colour = colour
      return piece
    end
    def new_queen(colour)
      piece = Queen.new
      piece.colour = colour
      return piece
    end
    def new_king(colour)
      piece = King.new
      piece.colour = colour
      return piece
    end

    def new_placement(file, rank)
      placement = Placement.new
      placement.file = file
      placement.rank = rank
      return placement
    end
    def new_move(piece_type, from_file, from_rank, to_file, to_rank, capture)
      move = Move.new
      move.piece_type = piece_type
      move.from_file = from_file
      move.from_rank = from_rank
      move.to_file = to_file
      move.to_rank = to_rank
      move.capture = capture
      return move
    end

    def new_history
      history = History.new
      history.moved_once = false
      return history
    end
    def new_tracker
      tracker = Tracker.new
      tracker.factory = self
      return tracker
    end
  end
end
