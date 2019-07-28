export TERM=xterm
ppath=$(pwd)
logfile=$ppath"/buildLinux.log"
unitybin="$HOME/Unity/Hub/Editor/2018.3.14f1/Editor/Unity"
set -x
$unitybin -quit -batchmode -logFile $logfile -projectPath $ppath -executeMethod Builder.buildLinux &
rm $logfile && touch $logfile && tail -f $logfile
