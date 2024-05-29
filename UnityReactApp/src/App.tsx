import { Unity, useUnityContext } from "react-unity-webgl";
import {SDKEnv} from "./js/SDKEnv"
import './App.css'

function App() {
  window.GameGlobal = {
    SDKEnv :SDKEnv
  }
  const { unityProvider, sendMessage } = useUnityContext({
    loaderUrl: "src/Build/WebOutput.loader.js",
    dataUrl: "src/Build/5aed6e013a2b69bf81bf5323297339a1.data",
    frameworkUrl: "src/Build/79a1763f435f9543ea745aa878a484f0.js",
    codeUrl: "src/Build/2f5d993f206acded17ed559ae6b030d8.wasm",
  });

  function TestUnity()
  {
    let info = {
      numValue:1,
      strValue:"test",
    }
    sendMessage('SDKEnvBridge', 'BridgeCall',  JSON.stringify(info));
  }

  return (
    <>
      <div className="header">
        <button onClick={() =>TestUnity()}>
          count
        </button>
      </div>
      <Unity unityProvider={unityProvider} />;
    </>
  )
}

export default App
