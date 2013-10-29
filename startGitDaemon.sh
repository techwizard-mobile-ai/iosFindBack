# Starts a git daemon in the current directory assuming that there is the .git folder
# Man: http://linux.die.net/man/1/git-daemon

git daemon --export-all --verbose --reuseaddr --base-path=.

