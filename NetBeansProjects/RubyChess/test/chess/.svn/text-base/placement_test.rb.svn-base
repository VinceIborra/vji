$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'vji'
require 'chess'

module Chess
  
  class PlacementTest < Test::Unit::TestCase

    def test_attr_file
      placement = Placement.new
      assert_nil placement.file
      placement.file = File::File_a
      assert_not_nil placement.file
      assert_equal File::File_a, placement.file
    end

    def test_attr_rank
      placement = Placement.new
      assert_nil placement.rank
      placement.rank = Rank::Rank_1
      assert_not_nil placement.rank
      assert_equal Rank::Rank_1, placement.rank
    end
  end
end
