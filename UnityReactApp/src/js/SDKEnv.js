const AppInfo = {
    APP_VER:'1.0.0',
    ASSET_VER:'6'
}

export const SDKEnv = {
    DATA_CDN:'',
    Init:function(callBack)
    {
        console.log("Init");
        let info={
            cdn:this.DATA_CDN,
            appVer:AppInfo.APP_VER,
            assetVer:AppInfo.ASSET_VER,
        }

        if(callBack){
            callBack(info);
        }
    },
    Log:function(logType,content){
        console.log("logType" + logType + "content:" + content);
    }
}
