// import react hooks
import { useEffect, useState } from "react"

//define the bowler type for the typescript
type Bowler = {
  bowlerId: number
  bowlerFirstName: string
  bowlerMiddleInit: string | null
  bowlerLastName: string
  teamName: string
  bowlerAddress: string
  bowlerCity: string
  bowlerState: string
  bowlerZip: string
  bowlerPhoneNumber: string
}

//react component that displays a table of bowlers
function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([])

  // state to store the list of bowlers
  useEffect(() => {
    fetch("http://localhost:5055/bowlers")
      .then((response) => response.json())
      .then((data) => setBowlers(data))
  }, [])

  //render data inside a table
  return (
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>

      <tbody>
        {bowlers.map((b) => (
          <tr key={b.bowlerId}>
            <td>
              {b.bowlerFirstName} {b.bowlerMiddleInit ?? ""} {b.bowlerLastName}
            </td>
            <td>{b.teamName}</td>
            <td>{b.bowlerAddress}</td>
            <td>{b.bowlerCity}</td>
            <td>{b.bowlerState}</td>
            <td>{b.bowlerZip}</td>
            <td>{b.bowlerPhoneNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}

//export the component so it can be used in other files
export default BowlerTable