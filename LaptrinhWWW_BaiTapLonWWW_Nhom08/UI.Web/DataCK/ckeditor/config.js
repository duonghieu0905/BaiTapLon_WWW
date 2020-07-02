/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.language = "en";
    config.filebrowserBrowseUrl = "/DataCK/ckfinder/ckfinder.html";
    config.filebrowserImageBrowseUrl = "/DataCK/ckfinder/ckfinder.html?type=Images";
    config.filebrowserFlashBrowseUrl = "/DataCK/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/DataCK/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    config.filebrowserImageUploadUrl = "/DataCK/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = "/DataCK/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

};
