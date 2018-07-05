$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'chess'

module Chess
  class MoveTest < Test::Unit::TestCase

    attr_accessor :factory

    def setup
      @factory = Factory.new
    end

    def test_attributes

      move = Move.new
      move.piece_type = Pawn
      move.from_rank = Rank::Rank_7
      move.from_file = File::File_a
      move.to_rank = Rank::Rank_6
      move.to_file = File::File_a
      move.capture = true

      assert_equal(Pawn, move.piece_type)
      assert_equal(Rank::Rank_7, move.from_rank)
      assert_equal(File::File_a, move.from_file)
      assert_equal(Rank::Rank_6, move.to_rank)
      assert_equal(File::File_a, move.to_file)
      assert(move.capture)
    end

    def test_equals_value
      move1 = factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_g, false)
      move2 = factory.new_move(Pawn, Rank::Rank_6, File::File_f, Rank::Rank_7, File::File_f, false)
      move3 = factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_g, false)
      assert_not_equal(move1, move2)
      assert_equal(move1, move3)
    end
    def test_equals_arrays_of_pieces
      array1 = [
        factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_g, false),
        factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_g, false)
      ]
      array2 = [
        factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_g, false),
        factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_g, false)
      ]
      assert_equal(array1, array2)
    end

  end
end
