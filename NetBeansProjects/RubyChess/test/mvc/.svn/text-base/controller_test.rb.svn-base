$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'chess'
require 'mvc'

module Mvc
  class ControllerTest < Test::Unit::TestCase

    attr_accessor :factory, :chess_factory

    def setup
      @factory = Factory.new
      @chess_factory = Chess::Factory.new
      @board = chess_factory.new_board
    end

    def test_attributes
      board = chess_factory.new_board
      message = "some message"
      controller = Controller.new
      controller.board = board
      controller.message = message

      assert_equal(board, controller.board)
      assert_equal(message, controller.message)
    end

    def test_process_arrange_command
      board = chess_factory.new_board()
      controller = factory.new_controller(board)
      command = factory.new_arrange_command()

      assert_equal(0, board.pieces.count)
      controller.process_command(command)
      assert_equal(32, board.pieces.count)
    end

    def test_process_move_command
      board = chess_factory.new_board()
      board.arrange_pieces()
      controller = factory.new_controller(board)
      move = chess_factory.new_move(Chess::Pawn, Chess::File::File_a, Chess::Rank::Rank_2, Chess::File::File_a, Chess::Rank::Rank_3, false)
      command = factory.new_move_command(move)

      pawn = board.piece_at(Chess::File::File_a, Chess::Rank::Rank_2)
      assert_piece_equals(Chess::Pawn, Chess::Colour::White, pawn)

      controller.process_command(command)

      assert_piece_equals(Chess::Pawn, Chess::Colour::White, board.piece_at(Chess::File::File_a, Chess::Rank::Rank_3))
      assert_equal(pawn, board.piece_at(Chess::File::File_a, Chess::Rank::Rank_3))
      assert_nil(board.piece_at(Chess::File::File_a, Chess::Rank::Rank_2))
    end

    def test_process_move_command_with_message
      board = chess_factory.new_board()
      board.arrange_pieces()
      controller = factory.new_controller(board)
      move = chess_factory.new_move(Chess::Pawn, Chess::File::File_a, :rank_0, Chess::File::File_a, Chess::Rank::Rank_3, false)
      command = factory.new_move_command(move)

      assert_piece_equals(Chess::Pawn, Chess::Colour::White, board.piece_at(Chess::File::File_a, Chess::Rank::Rank_2))
      controller.process_command(command)
      assert_piece_equals(Chess::Pawn, Chess::Colour::White, board.piece_at(Chess::File::File_a, Chess::Rank::Rank_2))
      assert_equal("<rank_0> is not a valid rank value.", controller.message)

    end

    def test_process_non_command
      board = chess_factory.new_board()
      non_command = factory.new_non_command("a non command message")
      controller = factory.new_controller(board)
      assert_nothing_raised { controller.process_command(non_command)}
      assert_equal(non_command.message, controller.message)
    end

  end
end
