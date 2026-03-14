import { useEffect, useState } from "react"

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

function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([])

  useEffect(() => {
    fetch("http://localhost:5055/bowlers")
      .then((response) => response.json())
      .then((data) => setBowlers(data))
  }, [])

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

export default BowlerTable