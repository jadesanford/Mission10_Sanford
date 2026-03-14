//import css
import "./App.css"
// import components
import Heading from "./components/Heading"
import BowlerTable from "./components/BowlerTable"

//controls what components show on the page
function App() {
  return (
    <>
      <Heading />
      <BowlerTable />
    </>
  )
}

//export the component so it can be used in other files
export default App