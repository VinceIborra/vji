$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'
require 'chess'

class Test::Unit::TestCase

  def assert_piece_equals(klass, colour, piece)
    assert_not_nil(piece)
    assert_kind_of(Chess::Piece, piece)
    assert_kind_of(klass, piece)
    assert_equal(colour, piece.colour)
  end

  def assert_new_board
    raise "assert_new_board not implemented yet."
  end

  def assert_cleared_board(board)
    Chess::File.values.each do |file|
      Chess::Rank.values.each do |rank|
          assert_nil(board.piece_at(file, rank), "There is a piece at #{file}:#{rank}.")
        end
    end
  end

  def assert_arranged_board(board)

    rank = Chess::Rank::Rank_8
    colour = Chess::Colour::Black
    assert_piece_equals(Chess::Rook, colour, board.piece_at(Chess::File::File_a, rank))
    assert_piece_equals(Chess::Knight, colour, board.piece_at(Chess::File::File_b, rank))
    assert_piece_equals(Chess::Bishop, colour, board.piece_at(Chess::File::File_c, rank))
    assert_piece_equals(Chess::Queen, colour, board.piece_at(Chess::File::File_d, rank))
    assert_piece_equals(Chess::King, colour, board.piece_at(Chess::File::File_e, rank))
    assert_piece_equals(Chess::Bishop, colour, board.piece_at(Chess::File::File_f, rank))
    assert_piece_equals(Chess::Knight, colour, board.piece_at(Chess::File::File_g, rank))
    assert_piece_equals(Chess::Rook, colour, board.piece_at(Chess::File::File_h, rank))

    rank = Chess::Rank::Rank_7
    Chess::File.values.each do |file|
      assert_piece_equals(Chess::Pawn, colour, board.piece_at(file, rank))
    end

    [Chess::Rank::Rank_6, Chess::Rank::Rank_5, Chess::Rank::Rank_4, Chess::Rank::Rank_3].each do |rank|
      Chess::File.values.each do |file|
        assert_nil(board.piece_at(file, rank))
      end
    end

    rank = Chess::Rank::Rank_2
    colour = Chess::Colour::White
    Chess::File.values.each do |file|
      assert_piece_equals(Chess::Pawn, colour, board.piece_at(file, rank))
    end

    rank = Chess::Rank::Rank_1
    assert_piece_equals(Chess::Rook, colour, board.piece_at(Chess::File::File_a, rank))
    assert_piece_equals(Chess::Knight, colour, board.piece_at(Chess::File::File_b, rank))
    assert_piece_equals(Chess::Bishop, colour, board.piece_at(Chess::File::File_c, rank))
    assert_piece_equals(Chess::Queen, colour, board.piece_at(Chess::File::File_d, rank))
    assert_piece_equals(Chess::King, colour, board.piece_at(Chess::File::File_e, rank))
    assert_piece_equals(Chess::Bishop, colour, board.piece_at(Chess::File::File_f, rank))
    assert_piece_equals(Chess::Knight, colour, board.piece_at(Chess::File::File_g, rank))
    assert_piece_equals(Chess::Rook, colour, board.piece_at(Chess::File::File_h, rank))
  end

end
