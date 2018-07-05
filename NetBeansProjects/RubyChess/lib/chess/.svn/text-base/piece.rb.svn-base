require 'chess'

module Chess
  class Piece

    include Assertions

    def colour=(colour)
      assert_valid_colour(colour)
      @colour = colour
    end
    def colour
      return @colour
    end

    def on_board=(on_board)
      @on_board = on_board
    end
    def on_board?
      return @on_board
    end

    def ==(piece)
      return false if (piece.nil?)
      return false if (!piece.kind_of?(self.class))
      return false if (piece.colour != self.colour)
      return true
    end

  end
end
