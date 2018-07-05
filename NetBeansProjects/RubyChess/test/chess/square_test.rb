$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'chess'

module Chess
  class SquareTest < Test::Unit::TestCase

    attr_reader :factory

    def setup
      @factory = Chess::Factory.new
    end

    def test_rank_accessor
      square = Square.new
      square.rank = :rank_1
      self.assert_equal(:rank_1, square.rank)
    end

    def test_file_accessor
      square = Square.new
      square.file = :file_1
      self.assert_equal(:file_1, square.file)
    end

    def test_shade
      square = Square.new
      square.shade = Shade::Dark
      self.assert_equal(Shade::Dark, square.shade)
    end

    def test_piece_accessor
      square = Square.new
      rook = Rook.new
      square.piece = rook
      self.assert_equal(rook, square.piece)
    end

    def test_equals_value
      assert_equal(factory.new_square(Rank::Rank_1, File::File_a, Shade::Dark), factory.new_square(Rank::Rank_1, File::File_a, Shade::Dark))
      assert_not_equal(factory.new_square(Rank::Rank_1, File::File_a, Shade::Dark), factory.new_square(Rank::Rank_2, File::File_a, Shade::Dark))
      assert_not_equal(factory.new_square(Rank::Rank_1, File::File_a, Shade::Dark), factory.new_square(Rank::Rank_1, File::File_b, Shade::Dark))
      assert_not_equal(factory.new_square(Rank::Rank_1, File::File_a, Shade::Dark), factory.new_square(Rank::Rank_1, File::File_a, Shade::Light))
    end
    def test_equals_arrays_of_squares
      array1 = [
        factory.new_square(Rank::Rank_1, File::File_a, Shade::Dark),
        factory.new_square(Rank::Rank_1, File::File_b, Shade::Dark),
        factory.new_square(Rank::Rank_1, File::File_a, Shade::Light)
      ]
      array2 = [
        factory.new_square(Rank::Rank_1, File::File_a, Shade::Dark),
        factory.new_square(Rank::Rank_1, File::File_b, Shade::Dark),
        factory.new_square(Rank::Rank_1, File::File_a, Shade::Light)
      ]
      assert_equal(array1, array2)
    end

  end
end
