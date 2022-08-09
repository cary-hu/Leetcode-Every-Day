#!/bin/sh

cd "$LEETCODE_HOME"

echo -e  "
▶ \033[33;1mCurrent folder: $(pwd)
\033[0m"

echo -e  "
▶ \033[33;1mgit pull
\033[0m"
git pull

echo -e  "
▶ \033[33;1mgit add .
\033[0m"
git add .

git status
echo -e "
▶ \033[33;1mcommit message:
\033[37;1m"
read msg
if [ ! $msg ]; then
    msg=$(date '+%Y%m%d')
fi
echo "Use default commit message: $msg"
echo -e "
▶ \033[33;1mgit commit -m '$msg'
\033[0m"
git commit -m "$msg"

echo -e "
▶ \033[33;1mgit push
"
echo -e "\033[37;1mstart pushing ...\033[0m
"
git push
echo -e "
\033[37;1mAll Done\033[0m"
