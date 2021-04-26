import React, { Component } from 'react';
import { render }
    from 'react-dom';

export class Battleship extends Component {
    static displayName = Battleship.name;

    constructor(props) {
        super(props);
        this.state = { grid: [], gridSquares: [], gridHit:[], shipsSquares: [], grid2: [], gridSquares2: [], shipsSquares2: [], loading: true, gameOver: false, gameOver2: false, playerturn: 1 }
        this.nextShot = this.nextShot.bind(this)
        this.getGridData = this.getGridData.bind(this);
    }

    componentDidMount() {
        this.getGridData()
    }


    static renderTd(row, gridrow, hit, occupied) {
        const square = {
            color: 'blue',
            height: 50,
            width: 50,
            backgroundColor: '#52D9E1',
            borderStyle: 'solid',
            borderWidth: 2,
            borderColor: 'white',
        }
        const red = {
            color: 'res',
            height: 50,
            width: 50,
            backgroundColor: 'red',
            borderStyle: 'solid',
            borderWidth: 2,
            borderColor: 'white',
        }
        const purple = {
            color: 'res',
            height: 50,
            width: 50,
            backgroundColor: 'purple',
            borderStyle: 'solid',
            borderWidth: 2,
            borderColor: 'white',
        }
        const grey = {
            color: 'res',
            height: 50,
            width: 50,
            backgroundColor: 'gray',
            borderStyle: 'solid',
            borderWidth: 2,
            borderColor: 'white',
        }
        if (gridrow === row) {
            if (hit && occupied === false) {
                return (

                    < td style={red}></ td >
                )
            }
            else if (hit && occupied === true) {
                return (

                    < td style={purple}></ td >
                )
            }
            else if (occupied) {
                return (

                    < td style={grey}></ td >
                )
            }
            else {
                return (

                    < td style={square}></ td >
                )
            }
        }
    }

    static renderGridTable(grids, grids2) {
        const numbers = [1,2,3,4,5,6,7,8,9,10]
        return (
            < div className='row' >

                < div style={{ padding: 10 }}>

                    < h3 > player 1 board </ h3 >

                    < table >

                        < thead >

                        </ thead >

                        < tbody >
                            {numbers.map(row =>
                                < tr >
                                    {
                                        grids.map(square =>
                                            Battleship.renderTd(row, square.y, square.hit, square.occupied)
                                        )}
                                </ tr >
                                )}

                        </ tbody >
                    </ table >
                </ div >

                < div style={{ padding: 10 }}>

                    < h3 > player 2 board </ h3 >

                    < table >

                        < thead >

                        </ thead >

                        < tbody >

                            {numbers.map(row =>
                                < tr >
                                    {
                                        grids2.map(square =>
                                            Battleship.renderTd(row, square.y, square.hit, square.occupied)
                                        )}
                                </ tr >
                            )}
                        </ tbody >
                    </ table >
                </ div >
            </ div >
        );
    }

    render() {
        let contents = this.state.loading
            ? < p >< em > Loading...</ em ></ p >
            : Battleship.renderGridTable(this.state.gridSquares, this.state.gridSquares2);

        if (this.state.gameOver === true) {
            return (

                < div >

                    < h1 id="tabelLabel" > BattleShip Game </ h1 >
                    < h1 > GameOver: Player Two Win </ h1 >
                    { contents}
                    < button className="btn btn-primary" onClick={this.getGridData}> Rest Grid </ button >
                </ div >
            )
        }
        else if (this.state.gameOver2 === true) {
            return (

                < div >

                    < h1 id="tabelLabel" > BattleShip Game </ h1 >
                    < h1 > GameOver: Player Two Win </ h1 >
                    { contents}
                    < button className="btn btn-primary" onClick={this.getGridData}> Rest Grid </ button >
                </ div >
            )
        }

        else {
            return (

                <>

                    < div >

                        < h1 id="tabelLabel" > BattleShip Game </ h1 >
                        {contents}
                    </ div >
                    < button className="btn btn-primary" onClick={this.nextShot}> Next Shot </ button >
                    < button className="btn btn-primary" onClick={this.getGridData}> Rest Grid </ button >

                </>
            )
        }
    }

    async nextShot() {
        if (this.state.playerturn === 1) {
            const response = await fetch('nextshotgridinfo');
            const data = await response.json();
            this.setState({ grid: data });
            this.setState({ gridSquares: this.state.grid.grid });
            this.setState({ gridHit: this.state.grid.hitSquares });
            this.setState({ shipsSquares: this.state.grid.shipsSquares });
            this.setState({ gameOver: this.state.grid.gameOver });
            this.setState({ playerturn: 2 })
        }
        else {
            const response = await fetch('nextshotgridinfo2');
            const data = await response.json();
            this.setState({ grid2: data });
            this.setState({ gridSquares2: this.state.grid2.grid });
            this.setState({ shipsSquares2: this.state.grid2.shipsSquares });
            this.setState({ gameOver2: this.state.grid2.gameOver });
            this.setState({ playerturn: 1 })
        }

        { console.log(this.state.shipsSquares) }
        { console.log(this.state.gridHit) }
    }

    async getGridData() {
        const response = await fetch('gridinfo');
        const data = await response.json();
        this.setState({ grid: data, loading: false });
        this.setState({ gridSquares: this.state.grid.grid });
        this.setState({ shipsSquares: this.state.grid.shipsSquares });
        this.setState({ gameOver: this.state.grid.gameOver });

        const response2 = await fetch('gridinfo2');
        const data2 = await response2.json();
        this.setState({ grid2: data2, loading: false });
        this.setState({ gridSquares2: this.state.grid2.grid });
        this.setState({ shipsSquares2: this.state.grid2.shipsSquares });
        this.setState({ gameOver2: this.state.grid2.gameOver });

    }
}