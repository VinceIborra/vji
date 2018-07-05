$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji/test/unit'
require 'chess'

module Chess
  
  class AssertionsTest < Test::Unit::TestCase

    include Chess::Assertions

    attr_reader :factory

    def setup
      @factory = Factory.new
    end

    def test_assert_valid_file
      File.values.each do |file|
        assert_nothing_raised do
          assert_valid_file file
        end
      end
      assert_exception_raised "<nil> is not a valid file value." do
        assert_valid_file nil
      end
      assert_exception_raised "<bob> is not a valid file value." do
        assert_valid_file :bob
      end
    end
    def test_assert_valid_rank
      Rank.values.each do |rank|
        assert_nothing_raised do
          assert_valid_rank rank
        end
      end
      assert_exception_raised "<nil> is not a valid rank value." do
        assert_valid_rank nil
      end
      assert_exception_raised "<bob> is not a valid rank value." do
        assert_valid_rank :bob
      end
    end
    def test_assert_valid_piece_type
      assert_valid_piece_type(King, factory.new_king(Colour::Black).class)
      assert_valid_piece_type(Queen, factory.new_queen(Colour::Black).class)
      assert_valid_piece_type(Knight, factory.new_knight(Colour::Black).class)
      assert_valid_piece_type(Bishop, factory.new_bishop(Colour::Black).class)
      assert_valid_piece_type(Rook, factory.new_rook(Colour::Black).class)
      assert_valid_piece_type(Pawn, factory.new_pawn(Colour::Black).class)
      assert_exception_raised "<Pawn> expected but was <bob>." do
        assert_valid_piece_type Pawn, :bob
      end
    end
    def test_assert_valid_shade
      Shade.values.each do |shade|
        assert_nothing_raised do
          assert_valid_shade(shade)
        end
      end
      assert_exception_raised "<bob> is not a valid shade value." do
        assert_valid_shade :bob
      end
    end
    def test_assert_valid_colour
      Colour.values.each do |colour|
        assert_nothing_raised do
          assert_valid_colour(colour)
        end
      end
      assert_exception_raised "<bob> is not a valid colour value." do
        assert_valid_colour :bob
      end
    end
  end
end
