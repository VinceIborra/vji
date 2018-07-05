$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'
require 'chess'

module Chess

  class BoardTest < Test::Unit::TestCase

    attr_reader :nil_file, :valid_file, :invalid_file
    attr_reader :nil_rank, :valid_rank, :invalid_rank
    attr_reader :nil_piece, :pawn_piece
    attr_reader :all_squares, :all_chess_pieces

    attr_reader :factory
    attr_reader :board, :new_board, :cleared_board, :arranged_board

    def setup
      @nil_file = nil
      @nil_rank = nil
      @valid_file = File::File_a
      @valid_rank = Rank::Rank_1
      @invalid_rank = :rank_blah
      @invalid_file = :rank_file
      @factory = Factory.new
      @board = factory.new_board
      @new_board = factory.new_board
      @cleared_board = factory.new_board
      @arranged_board = factory.new_board

      board.setup
      cleared_board.setup
      arranged_board.setup
      arranged_board.arrange_pieces

      setup_squares
      setup_pieces
    end
    def setup_squares
      @all_squares = []
      shade = Shade::Light
      Rank.values.reverse.each do |rank|
        File.values.each do |file|
          @all_squares << factory.new_square(file, rank, shade)
          if (shade == Shade::Dark)
            shade = Shade::Light
          else
            shade = Shade::Dark
          end
        end
        if (shade == Shade::Dark)
          shade = Shade::Light
        else
          shade = Shade::Dark
        end
      end
    end
    def setup_pieces
      @nil_piece = nil
      @pawn_piece = factory.new_pawn(Colour::Black)

      @all_chess_pieces = []
      @all_chess_pieces << factory.new_rook(Colour::Black)
      @all_chess_pieces << factory.new_knight(Colour::Black)
      @all_chess_pieces << factory.new_bishop(Colour::Black)
      @all_chess_pieces << factory.new_queen(Colour::Black)
      @all_chess_pieces << factory.new_king(Colour::Black)
      @all_chess_pieces << factory.new_bishop(Colour::Black)
      @all_chess_pieces << factory.new_knight(Colour::Black)
      @all_chess_pieces << factory.new_rook(Colour::Black)
      File.values.each do |file|
        @all_chess_pieces << factory.new_pawn(Colour::Black)
      end
      File.values.each do |file|
        @all_chess_pieces << factory.new_pawn(Colour::White)
      end
      @all_chess_pieces << factory.new_rook(Colour::White)
      @all_chess_pieces << factory.new_knight(Colour::White)
      @all_chess_pieces << factory.new_bishop(Colour::White)
      @all_chess_pieces << factory.new_queen(Colour::White)
      @all_chess_pieces << factory.new_king(Colour::White)
      @all_chess_pieces << factory.new_bishop(Colour::White)
      @all_chess_pieces << factory.new_knight(Colour::White)
      @all_chess_pieces << factory.new_rook(Colour::White)
    end

    def test_setup

      board = Board.new
      board.factory = self.factory
      assert_equal(0, board.squares.count)

      board.setup
      assert_equal(64, board.squares.count)

      first_expected_shade = Shade::Light
      [Rank::Rank_8, Rank::Rank_7, Rank::Rank_6, Rank::Rank_5, Rank::Rank_4, Rank::Rank_3, Rank::Rank_2, Rank::Rank_1].each do |rank|
        expected_shade = first_expected_shade
        [File::File_a, File::File_b, File::File_c, File::File_d, File::File_e, File::File_f, File::File_g, File::File_h].each do |file|
          square = board.square_at(file, rank)
          assert_not_nil(square)
          assert_equal(rank, square.rank)
          assert_equal(file, square.file)
          assert_equal(expected_shade, square.shade)
          if (expected_shade == Shade::Light)
            expected_shade = Shade::Dark
          else
            expected_shade = Shade::Light
          end
        end
        if (first_expected_shade == Shade::Light)
          first_expected_shade = Shade::Dark
        else
          first_expected_shade = Shade::Light
        end
      end
    end

    def test_squares
      assert_equal(all_squares, cleared_board.squares)
    end

    def test_square_at
      File.values.each do |file|
        Rank.values.each do |rank|
          square = nil
          assert_nothing_raised do
            square = board.square_at(file, rank)
          end
          assert_not_nil(square)
        end
      end
    end
    def test_square_assertions

      assert_exception_raised(
        "<nil> is not a valid file value.",
        & lambda {board.square_at(nil_file, valid_rank)}
      )
      assert_exception_raised(
        "<#{invalid_file}> is not a valid file value.",
        & lambda { board.square_at(invalid_file, valid_rank) }
      )

      assert_exception_raised(
        "<nil> is not a valid rank value.",
        & lambda {board.square_at(valid_file, nil_rank) }
      )
      assert_exception_raised(
        "<#{invalid_rank}> is not a valid rank value.",
        & lambda { board.square_at(valid_file, invalid_rank) }
      )

    end

    def test_pieces
      assert_equal([], cleared_board.pieces)
      assert_equal(all_chess_pieces, arranged_board.pieces)
    end

    def test_place_piece
      board = factory.new_board()
      pawn = factory.new_pawn(Colour::Black)
      board.setup()
      board.place_piece(pawn, File::File_a, Rank::Rank_1)
      assert_equal(pawn, board.piece_at(File::File_a, Rank::Rank_1))
      assert_not_nil board.tracker.history(pawn)
    end
    def test_place_piece_assertions

      assert_exception_raised("<nil> is not a valid piece value.") do
        board.place_piece(nil_piece, nil_file, valid_rank)
      end

      assert_exception_raised("<nil> is not a valid file value.") do
        board.place_piece(pawn_piece, nil_file, valid_rank)
      end
      assert_exception_raised("<#{invalid_file}> is not a valid file value.") do
        board.place_piece(pawn_piece, invalid_file, valid_rank)
      end

      assert_exception_raised("<nil> is not a valid rank value.") do
        board.place_piece(pawn_piece, valid_file, nil_rank)
      end
      assert_exception_raised("<#{invalid_rank}> is not a valid rank value.") do
        board.place_piece(pawn_piece, valid_file, invalid_rank)
      end

      board.arrange_pieces
      assert_exception_raised("A piece is already using #{valid_file}:#{valid_rank}.") do
        board.place_piece(pawn_piece, valid_file, valid_rank)
      end
    end

    def test_remove_piece
      brd = self.arranged_board
      assert_not_nil(brd.piece_at(valid_file, valid_rank))
      brd.remove_piece(valid_file, valid_rank)
      assert_nil(brd.piece_at(valid_file, valid_rank))
    end
    def test_remove_piece_assertions
      assert_exception_raised("<nil> is not a valid file value.") do
        board.remove_piece(nil_file, valid_rank)
      end
      assert_exception_raised("<#{invalid_file}> is not a valid file value.") do
        board.remove_piece(invalid_file, valid_rank)
      end
      assert_exception_raised("<nil> is not a valid rank value.") do
        board.remove_piece(valid_file, nil_rank)
      end
      assert_exception_raised("<#{invalid_rank}> is not a valid rank value.") do
        board.remove_piece(valid_file, invalid_rank)
      end
    end

    def test_piece_at
      assert_nil(cleared_board.piece_at(valid_file, valid_rank))
      assert_not_nil(arranged_board.piece_at(valid_file, valid_rank))
    end
    def test_piece_at_assertions
      assert_exception_raised(
        "<nil> is not a valid file value.",
        & lambda {board.piece_at(nil_file, valid_rank)}
      )
      assert_exception_raised(
        "<#{invalid_file}> is not a valid file value.",
        & lambda { board.piece_at(invalid_file, valid_rank) }
      )

      assert_exception_raised(
        "<nil> is not a valid rank value.",
        & lambda {board.piece_at(valid_file, nil_rank) }
      )
      assert_exception_raised(
        "<#{invalid_rank}> is not a valid rank value.",
        & lambda { board.piece_at(valid_file, invalid_rank) }
      )
    end

    def test_arrange_pieces

      board = factory.new_board
      assert_equal(0, board.pieces.count)

      board.arrange_pieces
      assert_equal(32, board.pieces.count)

      assert_arranged_board(board)
    end
    def test_arrange_pieces_for_an_in_progress_board

      board = factory.new_board
      assert_equal(0, board.pieces.count)

      board.arrange_pieces
      assert_equal(32, board.pieces.count)
      move = factory.new_move(Pawn, File::File_a, Rank::Rank_7, File::File_a, Rank::Rank_6, false)
      board.move_piece(move)
      board.arrange_pieces

      assert_arranged_board(board)
    end

    def test_clear_pieces
      brd = cleared_board
      assert_cleared_board(brd)
      brd.place_piece(pawn_piece, valid_file, valid_rank)
      brd.clear_pieces
      assert_cleared_board(brd)
    end

    def test_possible_moves_for_king
      brd = cleared_board
      brd.place_piece(factory.new_king(Colour::Black), File::File_f, Rank::Rank_5)
      possible_moves = brd.possible_moves(King, File::File_f, Rank::Rank_5)
      assert_not_nil(possible_moves)
      assert_kind_of(Array, possible_moves)
      assert_equal(
        [
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_g, false),
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_5, File::File_g, false),
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_4, File::File_g, false),
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_4, File::File_f, false),
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_4, File::File_e, false),
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_5, File::File_e, false),
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_e, false),
          factory.new_move(King, Rank::Rank_5, File::File_f, Rank::Rank_6, File::File_f, false)
        ],
        possible_moves
      )
    end
    def test_possible_moves_for_queen
      brd = cleared_board
      brd.place_piece(factory.new_queen(Colour::Black), File::File_d, Rank::Rank_4)
      possible_moves = brd.possible_moves(Queen, File::File_d, Rank::Rank_4)
      assert_not_nil(possible_moves)
      assert_kind_of(Array, possible_moves)
      assert_equal(
        [ # North East
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_5, File::File_e, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_6, File::File_f, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_7, File::File_g, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_8, File::File_h, false),

          # East
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_4, File::File_e, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_4, File::File_f, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_4, File::File_g, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_4, File::File_h, false),

          # South East
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_3, File::File_e, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_2, File::File_f, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_1, File::File_g, false),

          # South
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_3, File::File_d, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_2, File::File_d, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_1, File::File_d, false),

          # South West
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_3, File::File_c, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_2, File::File_b, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_1, File::File_a, false),

          # West
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_4, File::File_c, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_4, File::File_b, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_4, File::File_a, false),

           # North West
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_5, File::File_c, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_6, File::File_b, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_7, File::File_a, false),

          # North
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_5, File::File_d, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_6, File::File_d, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_7, File::File_d, false),
          factory.new_move(Queen, Rank::Rank_4, File::File_d, Rank::Rank_8, File::File_d, false),
        ],
        possible_moves
      )
    end
    def test_possible_moves_for_rook
      brd = cleared_board
      brd.place_piece(factory.new_rook(Colour::Black), File::File_d, Rank::Rank_5)
      possible_moves = brd.possible_moves(Rook, File::File_d, Rank::Rank_5)
      assert_not_nil(possible_moves)
      assert_kind_of(Array, possible_moves)
      assert_equal(
        [ # East
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_5, File::File_e, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_5, File::File_f, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_5, File::File_g, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_5, File::File_h, false),

          # South
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_4, File::File_d, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_3, File::File_d, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_2, File::File_d, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_1, File::File_d, false),

          # West
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_5, File::File_c, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_5, File::File_b, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_5, File::File_a, false),

          # North
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_6, File::File_d, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_7, File::File_d, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_8, File::File_d, false),
        ],
        possible_moves
      )
    end
    def test_possible_moves_for_bishop
      brd = cleared_board
      brd.place_piece(factory.new_bishop(Colour::Black), File::File_d, Rank::Rank_5)
      possible_moves = brd.possible_moves(Bishop, File::File_d, Rank::Rank_5)
      assert_not_nil(possible_moves)
      assert_kind_of(Array, possible_moves)
      assert_equal(
        [ # North East
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_6, File::File_e, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_7, File::File_f, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_8, File::File_g, false),

          # South East
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_4, File::File_e, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_3, File::File_f, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_2, File::File_g, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_1, File::File_h, false),

          # South West
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_4, File::File_c, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_3, File::File_b, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_2, File::File_a, false),

          # North West
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_6, File::File_c, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_7, File::File_b, false),
          factory.new_move(Rook, Rank::Rank_5, File::File_d, Rank::Rank_8, File::File_a, false),
        ],
        possible_moves
      )
    end
    def test_possible_moves_for_knight
      brd = cleared_board
      brd.place_piece(factory.new_knight(Colour::Black), File::File_d, Rank::Rank_4)
      possible_moves = brd.possible_moves(Knight, File::File_d, Rank::Rank_4)
      assert_not_nil(possible_moves)
      assert_kind_of(Array, possible_moves)
      assert_equal(
        [
          # North North East
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_6, File::File_e, false),

          # North East East
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_5, File::File_f, false),

          # South East East
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_3, File::File_f, false),

          # South South East
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_2, File::File_e, false),

          # South South West
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_2, File::File_c, false),

          # South West West
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_3, File::File_b, false),

          # North West West
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_5, File::File_b, false),

          # North North West
          factory.new_move(Knight, Rank::Rank_4, File::File_d, Rank::Rank_6, File::File_c, false)
        ],
        possible_moves
      )
    end
    def test_possible_moves_for_pawn
      brd = cleared_board
      brd.place_piece(factory.new_pawn(Colour::Black), File::File_d, Rank::Rank_4)
      brd.place_piece(factory.new_pawn(Colour::White), File::File_c, Rank::Rank_5)
      brd.place_piece(factory.new_pawn(Colour::White), File::File_e, Rank::Rank_5)
      possible_moves = brd.possible_moves(Pawn, File::File_d, Rank::Rank_4)
      assert_not_nil(possible_moves)
      assert_kind_of(Array, possible_moves)
      assert_equal(
        [ # North East
          factory.new_move(Pawn, File::File_d, Rank::Rank_4, File::File_e, Rank::Rank_5, true),

          # North West
          factory.new_move(Pawn, File::File_d, Rank::Rank_4, File::File_c, Rank::Rank_5, true),

          # North
          factory.new_move(Pawn, File::File_d, Rank::Rank_4, File::File_d, Rank::Rank_5, false),

          # North North
          factory.new_move(Pawn, File::File_d, Rank::Rank_4, File::File_d, Rank::Rank_6, false)
        ],
        possible_moves
      )
    end
    def test_possible_moves_for_pawn_when_it_has_already_moved_once

      # Move pawn once
      brd = cleared_board
      brd.place_piece(factory.new_pawn(Colour::Black), File::File_d, Rank::Rank_4)
      possible_moves = brd.possible_moves(Pawn, File::File_d, Rank::Rank_4)
      assert_equal(
        [
          factory.new_move(Pawn, File::File_d, Rank::Rank_4, File::File_d, Rank::Rank_5, false),
          factory.new_move(Pawn, File::File_d, Rank::Rank_4, File::File_d, Rank::Rank_6, false)
        ],
        possible_moves
      )
      brd.move_piece(possible_moves[0])

      # Can only move once a time from now on
      possible_moves = brd.possible_moves(Pawn, File::File_d, Rank::Rank_5)
      assert_equal(
        [ factory.new_move(Pawn, File::File_d, Rank::Rank_5, File::File_d, Rank::Rank_6, false) ],
        possible_moves
      )

    end

    def test_move_piece

      board = factory.new_board
      board.arrange_pieces
      pawn = board.piece_at(File::File_a, Rank::Rank_2)
      assert_piece_equals(Pawn, Colour::White, pawn)
      assert(!board.tracker.history(pawn).moved_once?)

      move = factory.new_move(Pawn, File::File_a, Rank::Rank_2, File::File_a, Rank::Rank_3, false)
      board.move_piece(move)
      assert_piece_equals(Pawn, Colour::White, board.piece_at(File::File_a, Rank::Rank_3))
      assert_equal(pawn, board.piece_at(File::File_a, Rank::Rank_3))
      assert_nil(board.piece_at(File::File_a, Rank::Rank_2))
      assert(board.tracker.history(pawn).moved_once?)

    end
    def test_move_piece_assertions

      board = factory.new_board
      board.arrange_pieces

      # Nil move
      exception = assert_raise AssertionFailedException do
        board.move_piece(nil)
      end
      assert_equal("<nil> is not a valid move value.", exception.message)

      # Invalid "from rank"
      move = factory.new_move(Pawn, File::File_a, :rank_9, File::File_a, Rank::Rank_3, false)
      exception = assert_raise AssertionFailedException do
        board.move_piece(move)
      end
      assert_equal("<rank_9> is not a valid rank value.", exception.message)

      # Invalid "from file"
      move = factory.new_move(Pawn, :file_i, Rank::Rank_2, File::File_a, Rank::Rank_3, false)
      exception = assert_raise AssertionFailedException do
        board.move_piece(move)
      end
      assert_equal("<file_i> is not a valid file value.", exception.message)

      # Invalid "to rank"
      move = factory.new_move(Pawn, File::File_a, Rank::Rank_2, File::File_a, :rank_9, false)
      exception = assert_raise AssertionFailedException do
        board.move_piece(move)
      end
      assert_equal("<rank_9> is not a valid rank value.", exception.message)

      # Invalid "to file"
      move = factory.new_move(Pawn, File::File_a, Rank::Rank_2, :file_i, Rank::Rank_3, false)
      exception = assert_raise AssertionFailedException do
        board.move_piece(move)
      end
      assert_equal("<file_i> is not a valid file value.", exception.message)

      # Invalid piece type
      move = factory.new_move(Rook, File::File_a, Rank::Rank_2, File::File_a, Rank::Rank_3, false)
      exception = assert_raise AssertionFailedException do
        board.move_piece(move)
      end
      assert_equal("<Pawn> expected but was <Rook>.", exception.message)

      # Attempt to capture a piece that's not there
      move = factory.new_move(Pawn, File::File_a, Rank::Rank_2, File::File_a, Rank::Rank_3, true)
      exception = assert_raise AssertionFailedException do
        board.move_piece(move)
      end
      assert_equal("No piece to capture at <Rank_3:File_a>.", exception.message)

    end

  end

end