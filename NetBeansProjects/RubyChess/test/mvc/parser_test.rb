$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'chess'
require 'mvc'

module Mvc
  class ParserTest < Test::Unit::TestCase

    attr_accessor :factory, :chess_factory, :parser

    def setup
      @factory = Factory.new
      @chess_factory = Chess::Factory.new
      @parser = factory.new_parser(chess_factory)
    end

    def test_parse_arrange
      str = "arrange"
      command = parser.parse(str)
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(ArrangeCommand, command)
    end

    def test_parse_move
      move_str = "pa2a3"
      command = parser.parse(move_str)
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(MoveCommand, command)
      assert_not_nil(command.move)
      assert_equal(Chess::Pawn, command.move.piece_type)
      assert_equal(:rank_2, command.move.from_rank)
      assert_equal(:file_a, command.move.from_file)
      assert_equal(:rank_3, command.move.to_rank)
      assert_equal(:file_a, command.move.to_file)
      assert_equal(false, command.move.capture)
    end

    def test_parse_exit_command
      str = "exit"
      command = parser.parse(str)
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(ExitCommand, command)
    end

    def test_parse_non_command
      str = "a rubbish string"
      command = parser.parse(str)
      assert_not_nil(command)
      assert_kind_of(Command, command)
      assert_kind_of(NonCommand, command)
      assert_equal("Could not parse command <a rubbish string>.", command.message)
    end
  end
end
