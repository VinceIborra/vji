class String

  # Copied from rails code base
  def demodulized
    return self.to_s.gsub(/^.*::/, '')
  end
end
