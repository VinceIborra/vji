$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'chess'

module Chess
  class RankTest < Test::Unit::TestCase

    def test_values
      assert_equal(
        [
          Rank::Rank_1,
          Rank::Rank_2,
          Rank::Rank_3,
          Rank::Rank_4,
          Rank::Rank_5,
          Rank::Rank_6,
          Rank::Rank_7,
          Rank::Rank_8
        ],
        Rank.values
      )
    end

  end
end
