%cd%
git init
git remote add origin https://github.com/Tobernt/Hellcrawler.git
git add .
git push --set-upstream origin master
git status
cmd /k git commit -m "First commit, empty project and .gitignore"