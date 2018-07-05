$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'
require 'chess'

module Chess
  
  class TrackerTest < Test::Unit::TestCase

    attr_reader :factory, :tracker

    def setup
      @factory = Factory.new
      @tracker = factory.new_tracker
    end
    def test_track
      piece = factory.new_pawn(Colour::Black)
      move = factory.new_move(Pawn, File::File_e, Rank::Rank_2, File::File_e, Rank::Rank_3, false)
      tracker.track(piece, move)
      assert_not_nil(tracker.history(piece))
    end
  end
end
