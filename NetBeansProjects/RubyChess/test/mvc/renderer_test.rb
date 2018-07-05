$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'chess'
require 'mvc'

module Mvc
  class RendererTest < Test::Unit::TestCase

    attr_accessor :factory, :chess_factory

    def setup
      @factory = Factory.new
      @chess_factory = Chess::Factory.new
    end

    def test_render_intro
      renderer = factory.new_renderer()
      assert_equal(
"
Commands:

  Move A Piece:
    <piece><from_file><from_rank>[<capture>]<to_file><to_rank>

    piece   - p,r,n,b,q,k
    file    - a,b,c,d,e,f,g,h
    rank    - 1,2,3,4,5,6,7,8
    capture - x

  Other:
    exit - to exit
",
    renderer.intro)
    end

    def test_prompt
      renderer = factory.new_renderer()
      assert_equal("> ", renderer.prompt)
    end

    def test_render_blank_board
      renderer = factory.new_renderer()
      board = chess_factory.new_board()
      renderered_str = renderer.render(board)
      assert_equal(
"
     A   B   C   D   E   F   G   H
   +---+---+---+---+---+---+---+---+
8  |   |---|   |---|   |---|   |---|
   +---+---+---+---+---+---+---+---+
7  |---|   |---|   |---|   |---|   |
   +---+---+---+---+---+---+---+---+
6  |   |---|   |---|   |---|   |---|
   +---+---+---+---+---+---+---+---+
5  |---|   |---|   |---|   |---|   |
   +---+---+---+---+---+---+---+---+
4  |   |---|   |---|   |---|   |---|
   +---+---+---+---+---+---+---+---+
3  |---|   |---|   |---|   |---|   |
   +---+---+---+---+---+---+---+---+
2  |   |---|   |---|   |---|   |---|
   +---+---+---+---+---+---+---+---+
1  |---|   |---|   |---|   |---|   |
   +---+---+---+---+---+---+---+---+
",
      renderered_str
      )
    end

    def test_render_arranged_board
      renderer = factory.new_renderer()
      board = chess_factory.new_board()
      board.arrange_pieces()
      renderered_str = renderer.render(board)
      assert_equal(
"
     A   B   C   D   E   F   G   H
   +---+---+---+---+---+---+---+---+
8  | R |-N-| B |-Q-| K |-B-| N |-R-|
   +---+---+---+---+---+---+---+---+
7  |-P-| P |-P-| P |-P-| P |-P-| P |
   +---+---+---+---+---+---+---+---+
6  |   |---|   |---|   |---|   |---|
   +---+---+---+---+---+---+---+---+
5  |---|   |---|   |---|   |---|   |
   +---+---+---+---+---+---+---+---+
4  |   |---|   |---|   |---|   |---|
   +---+---+---+---+---+---+---+---+
3  |---|   |---|   |---|   |---|   |
   +---+---+---+---+---+---+---+---+
2  | p |-p-| p |-p-| p |-p-| p |-p-|
   +---+---+---+---+---+---+---+---+
1  |-r-| n |-b-| q |-k-| b |-n-| r |
   +---+---+---+---+---+---+---+---+
",
      renderered_str
      )
    end

  end
end
