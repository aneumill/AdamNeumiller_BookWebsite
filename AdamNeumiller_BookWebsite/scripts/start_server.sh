export NVM_DIR="$HOME/.nvm"
[ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh"
[ -s "$NVM_DIR/bash_completion" ] && \. "$NVM_DIR/bash_completion"
cd /var/www/html/foo/FOO/bin/Release/netcoreapp3.0/linux -x64/publish
pm2 start "dotnet FOO.dll" --name tmro