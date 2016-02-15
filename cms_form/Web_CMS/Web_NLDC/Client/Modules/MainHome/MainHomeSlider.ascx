<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeSlider.ascx.cs" Inherits="Web_NLDC.Client.Modules.MainHome.MainHomeSlider" %>
<div class="slider">
        <div style="min-height: 100px;">
            <div id="slider1_container" style="display: none; position: relative; margin: 0 auto;
                top: 0px; left: 0px; width: 1300px; height: 366px; overflow: hidden;">
                <!-- Loading Screen -->
                <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                    <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block;
                        top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                    <div style="position: absolute; display: block; background: url(../Styles/img/loading.gif) no-repeat center center;
                        top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                </div>
                <!-- Slides Container -->
                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1300px;
                    height: 366px; overflow: hidden;">
                    <div>
                        <div id="dvTQPT" style="margin: 20px auto !important; width: 100%; position: fixed;">
                        </div>
                    </div>
                    <div>
                        <img alt="image" src2="/Styles/img/Slide1.jpg" width="100%" height="100%" />
                    </div>
                    <div>
                        <div id="dvLiveData" style="margin: auto">
                        </div>
                    </div>
                </div>
                <div u="navigator" class="jssorb21" style="position: absolute; bottom: 26px; left: 6px;">
                    <div u="prototype" style="position: absolute; width: 19px; height: 19px; text-align: center;
                        line-height: 19px; color: White; font-size: 12px;">
                    </div>
                </div>
                <span u="arrowleft" class="jssora21l" style="width: 55px; height: 55px; top: 123px;
                    left: 8px;"></span>
                <!-- Arrow Right -->
                <span u="arrowright" class="jssora21r" style="width: 55px; height: 55px; top: 123px;
                    right: 8px"></span>
                <!-- Arrow Navigator Skin End -->
                <a style="display: none" href="http://www.jssor.com">Bootstrap Slider</a>
            </div>
            <!-- Jssor Slider End -->
        </div>
    </div>