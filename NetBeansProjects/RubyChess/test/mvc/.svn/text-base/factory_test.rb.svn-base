$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'
require 'chess'
require 'mvc'

module Mvc
  class FactoryTest < Test::Unit::TestCase

    attr_reader :factory, :chess_factory

    def setup
      @factory = Factory.new
      @chess_factory = Chess::Factory.new
    end

    def test_new_arrange_command
      command = factory.new_arrange_command
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(ArrangeCommand, command)
    end
    def test_new_move_command
      move = chess_factory.new_move(Chess::Pawn, :rank_7, :file_a, :rank_6, :file_a, true)
      command = factory.new_move_command(move)
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(MoveCommand, command)
      assert_equal(move, command.move)
    end
    def test_new_exit_command
      command = factory.new_exit_command
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(ExitCommand, command)
    end
    def test_new_non_command
      command = factory.new_non_command("some message")
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(NonCommand, command)
    end

    def test_new_controller
      board = chess_factory.new_board()
      controller = factory.new_controller(board)
      assert_equal(board, controller.board)
    end
    def test_new_renderer
      renderer = factory.new_renderer()
      assert_not_nil(renderer)
      assert_kind_of(Renderer, renderer)
    end
    def test_new_parser
      parser = factory.new_parser(chess_factory)
      assert_not_nil(parser)
      assert_kind_of(Parser, parser)
      assert_not_nil(parser.factory)
      assert_equal(factory, parser.factory)
      assert_not_nil(chess_factory, parser.chess_factory)
    end
    def test_new_driver
      parser = factory.new_parser(chess_factory)
      board = chess_factory.new_board
      controller = factory.new_controller(board)
      renderer = factory.new_renderer()
      driver = factory.new_driver(board, parser, controller, renderer)
      assert_not_nil(driver)
      assert_kind_of(Driver, driver)
      assert_equal(board, driver.board)
      assert_equal(parser, driver.parser)
      assert_equal(controller, driver.controller)
      assert_equal(renderer, driver.renderer)
    end
  end
end
