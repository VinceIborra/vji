$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'chess'

module Chess
  class FactoryTest < Test::Unit::TestCase

    attr_reader :factory,
                :nil_file, :invalid_file, :valid_file,
                :nil_rank, :invalid_rank, :valid_rank,
                :nil_shade, :invalid_shade, :valid_shade

    def setup
      @factory = Factory.new
      @nil_file = nil
      @invalid_file = :file
      @valid_file = File::File_a
      @nil_rank = nil
      @invalid_rank = :rank
      @valid_rank = Rank::Rank_1
      @nil_shade = nil
      @invalid_shade = :shade
      @valid_shade = Shade::Dark
    end

    def test_new_square
      square = self.factory.new_square(File::File_a, Rank::Rank_1, Shade::Dark)
      assert_not_nil(square)
      assert_kind_of(Square, square)
      assert_equal(File::File_a, square.file)
      assert_equal(Rank::Rank_1, square.rank)
      assert_equal(Shade::Dark, square.shade)
      assert_nil(square.piece)
    end
    def test_new_board

      board = self.factory.new_board

      self.assert_not_nil(board)
      self.assert_kind_of(Board, board)

      self.assert_not_nil(board.factory)
      self.assert_kind_of(Factory, board.factory)
      self.assert_equal(self.factory, board.factory)

      assert_not_nil board.tracker
      assert_kind_of Tracker, board.tracker

      self.assert_equal(64, board.squares.count)

      self.assert_equal(0, board.pieces.count)
    end

    def test_new_pawn
      piece = factory.new_pawn(Colour::Black)

      self.assert_not_nil(piece)
      self.assert_kind_of(Piece, piece)
      self.assert_kind_of(Pawn, piece)

      self.assert_equal(Colour::Black, piece.colour)
    end
    def test_new_rook
      piece = factory.new_rook(Colour::Black)

      self.assert_not_nil(piece)
      self.assert_kind_of(Piece, piece)
      self.assert_kind_of(Rook, piece)

      self.assert_equal(Colour::Black, piece.colour)
    end
    def test_new_knight
      piece = factory.new_knight(Colour::Black)

      self.assert_not_nil(piece)
      self.assert_kind_of(Piece, piece)
      self.assert_kind_of(Knight, piece)

      self.assert_equal(Colour::Black, piece.colour)
    end
    def test_new_bishop
      piece = factory.new_bishop(Colour::Black)

      self.assert_not_nil(piece)
      self.assert_kind_of(Piece, piece)
      self.assert_kind_of(Bishop, piece)

      self.assert_equal(Colour::Black, piece.colour)
    end
    def test_new_queen
      piece = factory.new_queen(Colour::Black)

      self.assert_not_nil(piece)
      self.assert_kind_of(Piece, piece)
      self.assert_kind_of(Queen, piece)

      self.assert_equal(Colour::Black, piece.colour)
    end
    def test_new_king
      piece = factory.new_king(Colour::Black)

      self.assert_not_nil(piece)
      self.assert_kind_of(Piece, piece)
      self.assert_kind_of(King, piece)

      self.assert_equal(Colour::Black, piece.colour)
    end

    def test_new_placement
      placement = factory.new_placement(File::File_a, Rank::Rank_1)
      assert_equal(File::File_a, placement.file)
      assert_equal(Rank::Rank_1, placement.rank)
    end
    def test_new_move
      move = factory.new_move(Pawn, :file_a, :rank_7, :file_a, :rank_6, true)
      assert_equal(Pawn, move.piece_type)
      assert_equal(:file_a, move.from_file)
      assert_equal(:rank_7, move.from_rank)
      assert_equal(:file_a, move.to_file)
      assert_equal(:rank_6, move.to_rank)
      assert(move.capture)
    end

    def test_new_piece_history
      history = factory.new_history
      assert_kind_of History, history
      assert_equal false, history.moved_once
    end
    def test_new_tracker
      tracker = factory.new_tracker
      assert_kind_of Tracker, tracker
      assert_equal(factory, tracker.factory)
    end

    def test_new_square_assertions
      assert_exception_raised("<nil> is not a valid file value.") do
        factory.new_square(nil_file, valid_rank, valid_shade)
      end
      assert_exception_raised("<file> is not a valid file value.") do
        factory.new_square(invalid_file, valid_rank, valid_shade)
      end
      assert_nothing_raised do
        factory.new_square(valid_file, valid_rank, valid_shade)
      end

      assert_exception_raised("<nil> is not a valid rank value.") do
        factory.new_square(valid_file, nil_rank, valid_shade)
      end
      assert_exception_raised("<rank> is not a valid rank value.") do
        factory.new_square(valid_file, invalid_rank, valid_shade)
      end
      assert_nothing_raised do
        factory.new_square(valid_file, valid_rank, valid_shade)
      end

      assert_exception_raised("<nil> is not a valid shade value.") do
        factory.new_square(valid_file, valid_rank, nil_shade)
      end
      assert_exception_raised("<shade> is not a valid shade value.") do
        factory.new_square(valid_file, valid_rank, invalid_shade)
      end
      assert_nothing_raised do
        factory.new_square(valid_file, valid_rank, valid_shade)
      end
    end
    def test_new_pawn
      fail("blah")
    end
    def test_new_rook
      fail("blah")
    end
    def test_new_knight
      fail("blah")
    end
    def test_new_bishop
      fail("blah")
    end
    def test_new_queen
      fail("blah")
    end
    def test_new_king
      fail("blah")
    end
    def test_new_placement
      fail("blah")
    end
    def test_new_move
      fail("blah")
    end
    def test_new_piece_history
      fail("blah")
    end
    def test_new_tracker
      fail("blah")
    end

  end
end
