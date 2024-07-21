import React, { Component } from 'react';
import './Home.css'
export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <div id="dashboardDepot" className="h-100">
              <div className="Fullscreen" style={{ backgroundImage: `url(../clientApp/content/images/welcome.jpg)` }}>
                <div className="welcome-text-view">
                    <div className="welcome-black">Welcome to</div>
                    <div className="welcome-text">OneVision Depot</div>
                    <div className="env-text">FTE</div>
                </div>

            </div>
        </div>
    );
  }
}
