%cd%
set /p Input=Enter commit comment: 
git config --global http.version HTTP/1.1
git init
git remote add origin https://github.com/Tobernt/Hellcrawler.git
git add .
git status
git commit -m "%Input%"
git push
cmd /k 