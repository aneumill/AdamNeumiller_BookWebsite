﻿export $NVM_DIR="$HOME/.nvm"
[ - "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh"
[ -s "$NVM_DIR/bash_completion" ] && \. "$NVM_DIR/bash_completion"
pm2 stop foo
pm2 delete foo