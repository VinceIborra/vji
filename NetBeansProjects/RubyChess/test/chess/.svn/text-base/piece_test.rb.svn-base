$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'
require 'chess'

module Chess
  class PieceTest < Test::Unit::TestCase

    attr_reader :factory, :piece
    attr_reader :nil_colour, :invalid_colour

    def setup
      @factory = Factory.new
      @piece = factory.new_pawn(Colour::Black)
      @nil_colour = nil
      @invalid_colour = :blue
    end

    def test_attr_colour
      assert_equal(Colour::Black, piece.colour)
      piece.colour = Colour::White
      assert_equal(Colour::White, piece.colour)
      assert_exception_raised "<#{invalid_colour}> is not a valid colour value." do
        piece.colour = invalid_colour
      end
    end
    def test_attr_on_board
      assert(!piece.on_board?)
      piece.on_board = true
      assert(piece.on_board?)
    end

    def test_equals_value
      assert(factory.new_pawn(Colour::Black), factory.new_pawn(Colour::Black))
      assert_not_equal(factory.new_pawn(Colour::Black), factory.new_pawn(Colour::White))
      assert_not_equal(factory.new_pawn(Colour::Black), factory.new_king(Colour::Black))
    end
    def test_equals_arrays_of_pieces
      array1 = [ factory.new_pawn(Colour::Black), factory.new_king(Colour::Black)]
      array2 = [ factory.new_pawn(Colour::Black), factory.new_king(Colour::Black)]
      assert_equal(array1, array2)
    end
  end
end
