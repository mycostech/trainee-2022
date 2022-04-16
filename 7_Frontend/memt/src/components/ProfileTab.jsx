import React from "react";

export default function ProfileTab() {
  return (
    <>
      <div className="profile">
        <div className="profile-header">
          <div className="profile-header-image">
            <img src="/images/placeholder-image.png" alt="" />
          </div>
          <div className="profile-header-bio">
            <h1>Nickname</h1>
            <h3>Name Example</h3>
          </div>
        </div>
        <div className="profile-body">
          <span className="profile-body-text">Role: Junior Software Engineer</span>
          <span className="profile-body-text">BirthDate: xx/xx/xxxx</span>
          <span className="profile-body-text">Email: example@email.com</span>
          <span className="profile-body-text">Phone: +xx xx-xxxxxxx</span>
          <span className="profile-body-text">
            Address: Lorem ipsum dolor sit amet, consectetur adipisicing elit. Soluta, laudantium voluptatibus reprehenderit eaque mollitia doloremque
            iure natus dolore excepturi!
          </span>
        </div>
      </div>
    </>
  );
}
