export TERM=xterm
ppath=$(pwd)
unitybin="$HOME/Unity/Hub/Editor/2018.3.14f1/Editor/Unity"
$unitybin -quit -batchmode -logFile buildLinux.log -projectPath $ppath -executeMethod Builder.buildLinux
