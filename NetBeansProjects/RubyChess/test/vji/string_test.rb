require 'vji'

class StringTest < Test::Unit::TestCase
  def test_demodulized
    assert_equal("AClassName", "Some::Long::Module::Name::AClassName".demodulized)
  end
end
