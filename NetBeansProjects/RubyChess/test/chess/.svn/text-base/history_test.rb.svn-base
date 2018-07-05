$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'
require 'chess'

module Chess
  
  class HistoryTest < Test::Unit::TestCase

    include Chess::Assertions

    attr_reader :factory

    def setup
      @factory = Factory.new
    end

    def test_attr_moved_once
      history = factory.new_history
      assert_equal(false, history.moved_once?)
      history.moved_once = true
      assert_equal(true, history.moved_once?)
    end

    def test_track
      history = factory.new_history
      assert_equal(false, history.moved_once?)

      placement = factory.new_placement(File::File_f, Rank::Rank_2)
      history.track(placement)
      assert_equal(false, history.moved_once?)

      move = factory.new_move(Pawn, File::File_f, Rank::Rank_2, File::File_f, Rank::Rank_3, false)
      history.track(move)
      assert_equal(true, history.moved_once?)
    end
  end
end
