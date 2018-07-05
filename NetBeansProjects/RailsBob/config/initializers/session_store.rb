# Be sure to restart your server when you modify this file.

# Your secret key for verifying cookie session data integrity.
# If you change this key, all old sessions will become invalid!
# Make sure the secret is at least 30 characters and all random, 
# no regular words or you'll be exposed to dictionary attacks.
ActionController::Base.session = {
  :key         => '_RailsBob_session',
  :secret      => '98290d0c03da6c91fc0e060818d348718f3aa358fff766a8de428aac707fe4e2061919d5caf7aaedb044ed7e4026ce8dfbd588ee3a91ae762379011a4733454a'
}

# Use the database for sessions instead of the cookie-based default,
# which shouldn't be used to store highly confidential information
# (create the session table with "rake db:sessions:create")
# ActionController::Base.session_store = :active_record_store
